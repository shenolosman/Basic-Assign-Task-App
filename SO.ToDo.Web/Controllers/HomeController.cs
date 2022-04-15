using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Web.CustomFilters;
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

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [ActionName("Register")]
        [MyCustomFilters]
        [HttpPost]
        public IActionResult RegisterConfirm(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                // Do some work
            }
            //server-side validation!
            //ModelState.AddModelError(nameof(UserRegisterViewModel.Name), "User Name is Required!");

            return View(nameof(Register));
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