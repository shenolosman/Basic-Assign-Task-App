using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }
        public async Task<IActionResult> GetNotification()
        {
            TempData["Active"] = "Notification";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var notification = _notificationService.GetNotRead(user.Id);
            var models = new List<NotificationListViewModel>();
            foreach (var item in notification)
            {
                var model = new NotificationListViewModel
                {
                    Comment = item.Comment,
                    Id = item.Id
                };
                models.Add(model);
            }
            return View(models);
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
