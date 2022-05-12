using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.DTO.DTOs.TaskDtos;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.BaseController;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : BaseIdentityController
    {
        private readonly IMyTaskService _myTaskService;
        private readonly IMapper _mapper;

        public TaskController(IMyTaskService myTaskService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _myTaskService = myTaskService;
            _mapper = mapper;
        }
        public async Task<IActionResult> DoneTasks(int page = 1)
        {
            TempData["Active"] = "DoneTasks";
            var user = await GetCurrentUserAsync();
            // var tasks = _myTaskService.GetAllTablesWithNotDone(out totalPage, user.Id, page);
            var task = _mapper.Map<List<MyTaskAllListDto>>(
                _myTaskService.GetAllTablesWithNotDone(out var totalPage, user.Id, page));

            ViewBag.AllPage = totalPage;
            ViewBag.ActivePage = page;
            //var models = new List<MyTaskAllListViewModel>();
            //foreach (var item in tasks)
            //{
            //    var model = new MyTaskAllListViewModel()
            //    {
            //        Description = item.Description,
            //        AppUser = item.AppUser,
            //        CreatedTime = item.CreatedTime,
            //        Id = item.Id,
            //        Rapports = item.Rapports,
            //        StateOfUrgent = item.StateOfUrgent,
            //        Title = item.Title
            //    };
            //    models.Add(model);
            //}
            return View(task);
        }
    }
}
