using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Admin.ViewComponents
{
    public class AdminWrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminWrapper(UserManager<AppUser> userManager)
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
            return View(model);
        }
    }
}
