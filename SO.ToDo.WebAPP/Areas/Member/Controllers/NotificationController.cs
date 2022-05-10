using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class NotificationController : Controller
    {

        public IActionResult GetNotification()
        {
            TempData["Active"] = "Notification";
            throw new NotImplementedException();
        }
    }
}
