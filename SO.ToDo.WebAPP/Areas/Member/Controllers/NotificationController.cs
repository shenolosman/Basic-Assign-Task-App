using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    public class NotificationController : Controller
    {
        [Authorize(Roles = "Member")]
        [Area("Member")]
        public IActionResult GetNotification()
        {
            TempData["Active"] = "Notification";
            throw new NotImplementedException();
        }
    }
}
