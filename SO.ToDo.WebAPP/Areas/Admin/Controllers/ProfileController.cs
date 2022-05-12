using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.BaseController;
using SO.ToDo.WebAPP.Service;
using SO.ToDo.WebAPP.StringInfo;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        private readonly GeneralHandler _generalHandler;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper, GeneralHandler generalHandler) : base(userManager)
        {
            _mapper = mapper;
            _generalHandler = generalHandler;
        }
        public async Task<IActionResult> Index()
        {
            TempData[TempDataInfo.Active] = TempDataInfo.Profile;
            var user = await GetCurrentUserAsync();
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
                    TempData["m"] = "Update is succeeded!";
                    return RedirectToAction(nameof(Index));
                }
                AddError(result.Errors);
            }
            return View(model);
        }
    }
}
