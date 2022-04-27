using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.WebAPP.Models;

namespace SO.ToDo.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyTaskService _myTaskService;

        public HomeController(IMyTaskService myTaskService)
        {
            _myTaskService = myTaskService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View(new AppUserAddViewModel());
        }
        [HttpPost]
        public IActionResult Register(AppUserAddViewModel model)
        {
            return View();
        }
    }
}
