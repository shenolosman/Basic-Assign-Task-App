using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Web.Models;
using System.Diagnostics;

namespace SO.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            //can transfer just to view!
            ViewBag.Name = "Test-Viewbag";
            ViewData["Name"] = "Test-ViewData";
            //can transfer data to next action!
            TempData["Name"] = "Test-TempData";

            var customerlist = new List<CustomerViewModel>()
            {
                new (){Name = "Test 1"},
                new (){Name = "Test 2"},
                new (){Name = "Test 3"},
                new (){Name = "Test 4"},
                new (){Name = "Test 5"},
                new (){Name = "Test 6"},
            };
            return View(customerlist);
        }

        public IActionResult Result()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}