using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Models;

namespace SO.ToDo.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(AppUserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }

                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt!");
            }
            return View(nameof(Index), model);
        }
        public IActionResult Register()
        {
            return View(new AppUserAddViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username,
                    Name = model.Name,
                    Email = model.Email,
                    Surname = model.Surname
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (roleResult.Succeeded)
                    {
                        var userId = await _userManager.GetUserIdAsync(user);

                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home", new { area = "Member" });

                    }
                    foreach (var item in roleResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return View(model);
        }
    }
}
