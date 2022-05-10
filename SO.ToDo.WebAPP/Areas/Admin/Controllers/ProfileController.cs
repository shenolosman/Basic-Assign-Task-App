using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Profile";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var model = new AppUserListViewModel
            //{
            //    Email = user.Email,
            //    Id = user.Id,
            //    Name = user.Name,
            //    UserName = user.UserName,
            //    Picture = user.Picture,
            //    SurName = user.Surname
            //};

            return View(_mapper.Map<AppUserListDto>(user));
        }

        [HttpPost]
        //name="image" variable comes from img to equal iformfile
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile image)
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
                user.Surname = model.Surname;
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
