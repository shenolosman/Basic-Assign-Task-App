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
        //s=search
        public async Task<IActionResult> AssignUser(int id, string s, int page = 1)
        {
            TempData["Active"] = "Home";
            ViewBag.ActivePage = page;

            int totalPage;
            var users = _appUserService.GetUsersNotInAdminRole(out totalPage, s, page);
            ViewBag.AllPage = totalPage;
            var userListModel = new List<AppUserListViewModel>();
            foreach (var item in users)
            {
                var appUserModel = new AppUserListViewModel
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    Picture = item.Picture,
                    Name = item.Name,
                    SurName = item.Surname
                };
                userListModel.Add(appUserModel);
            }
            ViewBag.Users = userListModel;

            var myTask = await _myTaskService.GetStateOfUrgentWithId(id);
            var taskModel = new MyTaskListViewModel
            {
                Id = myTask.Id,
                StateOfUrgent = myTask.StateOfUrgent,
                CreatedTime = myTask.CreatedTime,
                Description = myTask.Description,
                Title = myTask.Title,
            };
            return View(taskModel);
        }
        [HttpPost]
        public IActionResult AssignUser()
        {
            throw new NotImplementedException();
        }
        public IActionResult Detail(int id)
        {
            TempData["Active"] = "Home";
            throw new NotImplementedException();
        }
        [HttpPost]
        public IActionResult Detail()
        {
            throw new NotImplementedException();
        }
    }
}
