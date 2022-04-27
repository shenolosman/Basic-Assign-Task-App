using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MyTaskController : Controller
    {
        private readonly IMyTaskService _myTaskService;
        private readonly IStateOfUrgentService _stateOfUrgentService;

        public MyTaskController(IMyTaskService myTaskService, IStateOfUrgentService stateOfUrgentService)
        {
            _myTaskService = myTaskService;
            _stateOfUrgentService = stateOfUrgentService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "MyTask";
            var tasks = _myTaskService.GetUnDoneStatesofUrgent();
            var models = new List<MyTaskListViewModel>();
            foreach (var item in tasks.Result)
            {
                MyTaskListViewModel model = new MyTaskListViewModel
                {
                    Id = item.Id,
                    Description = item.Description,
                    StateOfUrgent = item.StateOfUrgent,
                    CreatedTime = item.CreatedTime,
                    Title = item.Title,
                    IsDone = item.IsDone,
                    StateOfUrgentId = item.StateOfUrgentId
                };
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult Add()
        {
            TempData["Active"] = "MyTask";
            ViewBag.States = new SelectList(_stateOfUrgentService.GetAll(), "Id", "Type");
            return View(new MyTaskAddViewModel());
        }
        [HttpPost]
        public IActionResult Add(MyTaskAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _myTaskService.Add(new MyTask()
                {
                    Description = model.Description,
                    Title = model.Title,
                    StateOfUrgentId = model.StateOfUrgentId
                });
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            TempData["Active"] = "MyTask";
            var task = _myTaskService.GetById(id);
            MyTaskUpdateVievModel model = new MyTaskUpdateVievModel
            {
                Id = task.Id,
                StateOfUrgentId = task.StateOfUrgentId,
                Description = task.Description,
                Title = task.Title
            };
            ViewBag.State = new SelectList(_stateOfUrgentService.GetAll(), "Id", "Type", task.Id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(MyTaskUpdateVievModel model)
        {
            if (ModelState.IsValid)
            {
                _myTaskService.Edit(new MyTask()
                {
                    Title = model.Title,
                    Description = model.Title,
                    Id = model.Id,
                    StateOfUrgentId = model.Id
                });
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            //var task = _myTaskService.GetById(id);
            _myTaskService.Delete(new MyTask { Id = id });
            return Json(null);
        }
        //[HttpPost]
        //public IActionResult Delete(MyTaskDeleteVievModel model)
        //{
        //    return View();
        //}
    }
}
