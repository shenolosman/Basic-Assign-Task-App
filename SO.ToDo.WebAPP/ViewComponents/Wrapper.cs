using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //var model = new AppUserListViewModel()
            //{
            //    Email = user.Email,
            //    Id = user.Id,
            //    Name = user.Name,
            //    UserName = user.UserName,
            //    Picture = user.Picture,
            //    Surname = user.Surname
            //};
            var model = _mapper.Map<AppUserListDto>(user);
            var notifications = _notificationService.GetNotRead(user.Id).Count;
            ViewBag.NotificationsCount = notifications;
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);

            }
            return View("Member", model);
        }
    }
}
