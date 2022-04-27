using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;

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
    }
}
