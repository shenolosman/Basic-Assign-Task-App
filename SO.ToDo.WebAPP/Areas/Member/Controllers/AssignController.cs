﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.DTO.DTOs.RapportDtos;
using SO.ToDo.DTO.DTOs.TaskDtos;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class AssignController : Controller
    {
        private readonly IMyTaskService _myTaskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRapportService _rapportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public AssignController(IMyTaskService myTaskService, UserManager<AppUser> userManager, IRapportService rapportService, INotificationService notificationService, IMapper mapper)
        {
            _myTaskService = myTaskService;
            _userManager = userManager;
            _rapportService = rapportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "Assign";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var task = await _myTaskService.GetAllTables(x => x.AppUserId == user.Id && !x.IsDone);
            //var models = new List<MyTaskAllListViewModel>();
            //foreach (var item in task)
            //{
            //    var model = new MyTaskAllListViewModel
            //    {
            //        AppUser = item.AppUser,
            //        Id = item.Id,
            //        Rapports = item.Rapports,
            //        Description = item.Description,
            //        StateOfUrgent = item.StateOfUrgent,
            //        CreatedTime = item.CreatedTime,
            //        Title = item.Title
            //    };
            //    models.Add(model);
            //}
            var models =
                _mapper.Map<List<MyTaskAllListDto>>(
                    await _myTaskService.GetAllTables(x => x.AppUserId == user.Id && !x.IsDone));
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
            TempData["Active"] = "Assign";
            //var report = _rapportService.GetByTaskId(id);
            //var model = new RapportUpdateViewModel
            //{
            //    Id = report.Id,
            //    MyTask = report.MyTask,
            //    Title = report.Title,
            //    Details = report.Details,
            //    MyTaskId = report.MyTaskId
            //};
            var model = _mapper.Map<RapportUpdateDto>(_rapportService.GetByTaskId(id));
            return View(model);
        }
        [HttpPost]
        public IActionResult EditTasksRapport(RapportUpdateDto model)
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
            TempData["Active"] = "Assign";
            var task = _myTaskService.GetAllTables().Result.Find(x => x.Id == id);
            var model = new RapportAddDto
            {
                MyTaskId = id,
                MyTask = task
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskReport(RapportAddDto model)
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
