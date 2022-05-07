using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["Active"] = "Home";
            return View();
        }

        public IActionResult DoneTasks()
        {
            TempData["Active"] = "DoneTasks";
            throw new NotImplementedException();
        }

        public IActionResult Transmissions()
        {
            TempData["Active"] = "Transmissions";
            throw new NotImplementedException();
        }
    }
}
