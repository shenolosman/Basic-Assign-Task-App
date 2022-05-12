using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Service;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly GeneralHandler _generalHandler;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper, GeneralHandler generalHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _generalHandler = generalHandler;
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
            var model = _mapper.Map<AppUserListDto>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
                model.Picture = (string?)TempData["Picture"];
                user.Picture = await _generalHandler.SaveImageFile(model.ImageFile, model.Picture);
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.Id = model.Id;
                user.UserName = model.UserName;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["update"] = "Update is succeeded!";
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
