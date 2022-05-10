using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]
public class AssignmentController : Controller
{
    private readonly IAppUserService _appUserService;
    private readonly IFileService _fileService;
    private readonly INotificationService _notificationService;
    private readonly IMyTaskService _myTaskService;
    private readonly UserManager<AppUser> _userManager;

    public AssignmentController(IAppUserService appUserService, IMyTaskService myTaskService,
        UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService)
    {
        _appUserService = appUserService;
        _myTaskService = myTaskService;
        _userManager = userManager;
        _fileService = fileService;
        _notificationService = notificationService;
    }

    public async Task<IActionResult> Index()
    {
        TempData["Active"] = "Assignment";
        var myTasks = await _myTaskService.GetAllTables();
        if (ModelState.IsValid)
        {
            var models = myTasks.Select(item => new MyTaskAllListViewModel
            {
                AppUser = item.AppUser,
                CreatedTime = item.CreatedTime,
                Description = item.Description,
                Id = item.Id,
                StateOfUrgent = item.StateOfUrgent,
                Title = item.Title,
                Rapports = item.Rapports
            })
                .ToList();
            return View(models);
        }

        return View();
    }
    //s=search
    public async Task<IActionResult> AssignUser(int id, string s, int page = 1)
    {
        TempData["Active"] = "Assignment";
        ViewBag.ActivePage = page;
        ViewBag.Searched = s;
        var users = _appUserService.GetUsersNotInAdminRole(out var totalPage, s, page);
        ViewBag.AllPage = totalPage;
        var userListModel = users.Select(item => new AppUserListViewModel
        {
            Id = item.Id,
            UserName = item.UserName,
            Email = item.Email,
            Picture = item.Picture,
            Name = item.Name,
            SurName = item.Surname
        })
            .ToList();
        ViewBag.Users = userListModel;

        var myTask = await _myTaskService.GetStateOfUrgentWithId(id);
        var taskModel = new MyTaskListViewModel
        {
            Id = myTask.Id,
            StateOfUrgent = myTask.StateOfUrgent,
            CreatedTime = myTask.CreatedTime,
            Description = myTask.Description,
            Title = myTask.Title
        };
        return View(taskModel);
    }

    [HttpPost]
    public IActionResult AssignUser(UserTaskingViewModel model)
    {
        var updatedTask = _myTaskService.GetById(model.TaskId);
        updatedTask.AppUserId = model.UserId;

        _notificationService.Add(new Notification()
        {
            AppUserId = model.UserId,
            Comment = $"You assigned for this {updatedTask.Title} work."
        });

        _myTaskService.Edit(updatedTask);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detail(int id)
    {
        TempData["Active"] = "Assignment";
        var task = await _myTaskService.GetByReportId(id);
        var model = new MyTaskAllListViewModel
        {
            AppUser = task.AppUser,
            Id = task.Id,
            Description = task.Description,
            Title = task.Title,
            Rapports = task.Rapports
        };
        return View(model);
    }

    public IActionResult ChargeUser(UserTaskingViewModel model)
    {
        TempData["Active"] = "Assignment";
        var user = _userManager.Users.FirstOrDefault(x => x.Id == model.UserId);
        var task = _myTaskService.GetStateOfUrgentWithId(model.TaskId).Result;

        var userModel = new AppUserListViewModel
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Picture = user.Picture,
            SurName = user.Surname
        };

        var taskModel = new MyTaskListViewModel
        {
            Id = task.Id,
            StateOfUrgent = task.StateOfUrgent,
            Description = task.Description,
            Title = task.Title
        };

        var userTaskingListView = new UserTaskingListViewModel
        {
            AppUser = userModel,
            Task = taskModel
        };

        return View(userTaskingListView);
    }

    public async Task<IActionResult> MakeExcel(int id)
    {
        var list = await _myTaskService.GetByReportId(id);
        return File(await _fileService.ExportExcel(list.Rapports),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
    }

    public async Task<IActionResult> MakePdf(int id)
    {
        var list = await _myTaskService.GetByReportId(id);
        var path = _fileService.ExportPdf(list.Rapports);
        return File(path,
            "application/pdf", Guid.NewGuid() + ".pdf");
    }
}