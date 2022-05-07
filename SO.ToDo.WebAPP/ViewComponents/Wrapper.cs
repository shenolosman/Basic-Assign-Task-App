using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = new AppUserListViewModel()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Picture = user.Picture,
                SurName = user.Surname
            };
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);

            }
            return View("Member", model);
        }
    }
}
