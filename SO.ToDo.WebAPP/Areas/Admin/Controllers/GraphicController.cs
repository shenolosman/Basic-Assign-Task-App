using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SO.ToDo.BusinessLayer.Interfaces;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers;
[Authorize(Roles = "Admin")]
[Area("Admin")]
public class GraphicController : Controller
{
    private readonly IAppUserService _appUserService;
    public GraphicController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    public IActionResult Index()
    {
        TempData["Active"] = "Graphic";
        return View();
    }
    public IActionResult MostDoneTask()
    {
        var jsonString = JsonConvert.SerializeObject(_appUserService.GetUsersMostDoneTask());
        return Json(jsonString);
    }
    public IActionResult MostTaskHave()
    {
        var jsonString = JsonConvert.SerializeObject(_appUserService.GetUsersMostTaskHave());
        return Json(jsonString);
    }
}