using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AssignmentController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IMyTaskService _myTaskService;

        public AssignmentController(IAppUserService appUserService, IMyTaskService myTaskService)
        {
            _appUserService = appUserService;
            _myTaskService = myTaskService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "Home";
            var myTasks = _myTaskService.GetAllTables();
            var models = new List<MyTaskAllListViewModel>();
            foreach (var item in myTasks.Result)
            {
                var model = new MyTaskAllListViewModel
                {
                    AppUser = item.AppUser,
                    CreatedTime = item.CreatedTime,
                    Description = item.Description,
                    Id = item.Id,
                    StateOfUrgent = item.StateOfUrgent,
                    Title = item.Title,
                    Rapports = item.Rapports
                };
                models.Add(model);
            }
            return View(models);
        }

        public IActionResult AssignUser()
        {
            throw new NotImplementedException();
        }

        public IActionResult Detail()
        {
            throw new NotImplementedException();
        }
    }
}
