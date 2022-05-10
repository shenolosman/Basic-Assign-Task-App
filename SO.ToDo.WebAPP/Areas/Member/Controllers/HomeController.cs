using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        private readonly IMyTaskService _myTaskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRapportService _rapportService;
        private readonly INotificationService _notificationService;

        public HomeController(IMyTaskService myTaskService, UserManager<AppUser> userManager, IRapportService rapportService, INotificationService notificationService)
        {
            _myTaskService = myTaskService;
            _userManager = userManager;
            _rapportService = rapportService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Home";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var task = await _myTaskService.GetAllTables(x => x.AppUserId == user.Id && !x.IsDone);
            var models = new List<MyTaskAllListViewModel>();
            foreach (var item in task)
            {
                var model = new MyTaskAllListViewModel
                {
                    AppUser = item.AppUser,
                    Id = item.Id,
                    Rapports = item.Rapports,
                    Description = item.Description,
                    StateOfUrgent = item.StateOfUrgent,
                    CreatedTime = item.CreatedTime,
                    Title = item.Title
                };
                models.Add(model);
            }
            return View(models);
        }
        public async Task<IActionResult> MakeDoneTask(int id)
        {
            var updateTask = _myTaskService.GetById(id);
            updateTask.IsDone = true;
            _myTaskService.Edit(updateTask);

            var users = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var admin in users)
            {
                _notificationService.Add(new Notification()
                {
                    AppUserId = admin.Id,
                    Comment = $"{activeUser.Name} {activeUser.Surname} is done with report!"
                });
            }
            return Json(null);
        }
        public IActionResult EditTasksRapport(int id)
        {
            TempData["Active"] = "Home";
            var report = _rapportService.GetByTaskId(id);
            var model = new RapportUpdateViewModel
            {
                Id = report.Id,
                MyTask = report.MyTask,
                Title = report.Title,
                Details = report.Details,
                MyTaskId = report.MyTaskId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTasksRapport(RapportUpdateViewModel model)
        {
            //if (!ModelState.IsValid) return View(model);
            var report = _rapportService.GetByTaskId(model.Id);
            report.Title = model.Title;
            report.Details = model.Details;
            _rapportService.Edit(report);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddTaskReport(int id)
        {
            TempData["Active"] = "Home";
            var task = _myTaskService.GetAllTables().Result.Find(x => x.Id == id);
            var model = new RapportAddViewModel
            {
                MyTaskId = id,
                MyTask = task
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskReport(RapportAddViewModel model)
        {

            //if (!ModelState.IsValid) return View(model);
            _rapportService.Add(new Rapport()
            {
                Title = model.Title,
                Details = model.Details,
                MyTaskId = model.MyTaskId
            });
            var users = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);
            foreach (var admin in users)
            {
                _notificationService.Add(new Notification()
                {
                    AppUserId = admin.Id,
                    Comment = $"{activeUser.Name} {activeUser.Surname} created a new report!"
                });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
