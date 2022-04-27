using Microsoft.AspNetCore.Mvc;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
