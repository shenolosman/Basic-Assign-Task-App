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
    public class TaskController : Controller
    {
        private readonly IMyTaskService _myTaskService;
        private readonly UserManager<AppUser> _userManager;

        public TaskController(IMyTaskService myTaskService, UserManager<AppUser> userManager)
        {
            _myTaskService = myTaskService;
            _userManager = userManager;
        }
        public async Task<IActionResult> DoneTasks(int id, string s, int page = 1)
        {
            TempData["Active"] = "DoneTasks";
            ViewBag.ActivePage = page;
            //ViewBag.Searched = s;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            int totalPage;
            var tasks = _myTaskService.GetAllTablesWithNotDone(out totalPage, user.Id, page);
            ViewBag.AllPage = totalPage;
            var models = new List<MyTaskAllListViewModel>();
            foreach (var item in tasks)
            {
                var model = new MyTaskAllListViewModel()
                {
                    Description = item.Description,
                    AppUser = item.AppUser,
                    CreatedTime = item.CreatedTime,
                    Id = item.Id,
                    Rapports = item.Rapports,
                    StateOfUrgent = item.StateOfUrgent,
                    Title = item.Title
                };
                models.Add(model);
            }
            return View(models);
        }
    }
}
