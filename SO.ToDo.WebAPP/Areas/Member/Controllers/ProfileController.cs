using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Profile";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new AppUserListViewModel
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

        [HttpPost]
        //name="image" variable comes from img to equal iformfile
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
                if (image != null)
                {
                    var extension = Path.GetExtension(image.FileName);
                    var imgName = Guid.NewGuid() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imgName);
                    await using var stream = new FileStream(path, FileMode.Create);
                    await image.CopyToAsync(stream);
                    user.Picture = imgName;
                }
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.Id = model.Id;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["m"] = "Update is succeeded!";
                    return RedirectToAction(nameof(Index));
                }

                foreach (var identityError in result.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
            }
            return View(model);
        }
    }
}
