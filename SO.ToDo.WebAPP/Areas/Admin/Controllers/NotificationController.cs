using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers;

public class NotificationController : Controller
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public IActionResult GetNotification()
    {
        TempData["Active"] = "Notification";
        throw new NotImplementedException();
    }
}