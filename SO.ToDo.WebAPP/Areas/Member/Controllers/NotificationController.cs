using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.DTO.DTOs.NotificationDtos;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.BaseController;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> GetNotification()
        {
            TempData["Active"] = "Notification";
            var user = await GetCurrentUserAsync();
            //var notification = _notificationService.GetNotRead(user.Id);
            //var models = new List<NotificationListViewModel>();
            //foreach (var item in notification)
            //{
            //    var model = new NotificationListViewModel
            //    {
            //        Comment = item.Comment,
            //        Id = item.Id
            //    };
            //    models.Add(model);
            //}
            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetNotRead(user.Id)));
        }
        [HttpPost]
        public IActionResult GetNotification(int id)
        {
            var updateNotification = _notificationService.GetById(id);
            updateNotification.State = true;
            _notificationService.Edit(updateNotification);
            return RedirectToAction(nameof(GetNotification));
        }
    }
}
