using Microsoft.AspNetCore.Mvc;
using SO.ToDo.Web.CustomExtension;
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


            SetCookie();
            GetCookie();

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

        public IActionResult PageError(int? code)
        {
            ViewBag.Code = code;
            if (code == 404)
                ViewBag.Message = "Page Not Found";
            return View();
        }
        //client side
        public void SetCookie()
        {
            //Secure=True for https
            HttpContext.Response.Cookies.Append("Name", "String comes here!", new CookieOptions()
            {
                Expires = DateTimeOffset.MaxValue,
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });
        }
        //client side
        public string? GetCookie()
        {
            return HttpContext.Request.Cookies["Name"];
        }

        //server side
        public void SetSession()
        {
            HttpContext.Session.SetObject("Key", new UserRegisterViewModel()
            {
                Name = "bla bla bla",
                Email = "acme@mail.io"
            });
        }

        //server side
        public UserRegisterViewModel GetSession()
        {
            return HttpContext.Session.GetObject<UserRegisterViewModel>("Key");
        }
    }
}