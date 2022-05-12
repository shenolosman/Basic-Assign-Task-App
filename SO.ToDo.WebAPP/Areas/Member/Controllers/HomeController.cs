using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.BaseController;
using SO.ToDo.WebAPP.StringInfo;

namespace SO.ToDo.WebAPP.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMyTaskService _taskService;
        private readonly IRapportService _rapportService;

        public HomeController(INotificationService notificationService, UserManager<AppUser> userManager, IMyTaskService taskService, IRapportService rapportService) : base(userManager)
        {
            _notificationService = notificationService;
            _taskService = taskService;
            _rapportService = rapportService;
        }
        public async Task<IActionResult> Index()
        {
            TempData[TempDataInfo.Active] = TempDataInfo.Home;
            var user = await GetCurrentUserAsync();
            ViewBag.ReportCount = _rapportService.GetReportsByUserId(user.Id);
            ViewBag.CompletedTaskCount = _taskService.GetTaskCountCompletedWithUserId(user.Id);
            ViewBag.NotReadNotificationCount = _notificationService.GetNotReadCountByUserId(user.Id);
            ViewBag.MustCompleteTaskCount = _taskService.GetTaskCountMustCompleteByUserId(user.Id);
            return View();
        }
    }
}
