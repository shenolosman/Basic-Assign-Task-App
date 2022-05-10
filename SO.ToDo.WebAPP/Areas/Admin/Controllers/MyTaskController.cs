using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.DTO.DTOs.TaskDtos;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MyTaskController : Controller
    {
        private readonly IMyTaskService _myTaskService;
        private readonly IStateOfUrgentService _stateOfUrgentService;
        private readonly IMapper _mapper;

        public MyTaskController(IMyTaskService myTaskService, IStateOfUrgentService stateOfUrgentService, IMapper mapper)
        {
            _myTaskService = myTaskService;
            _stateOfUrgentService = stateOfUrgentService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "MyTask";
            //var tasks = _myTaskService.GetUnDoneStatesofUrgent();
            //var models = new List<MyTaskListViewModel>();
            //foreach (var item in tasks.Result)
            //{
            //    MyTaskListViewModel model = new MyTaskListViewModel
            //    {
            //        Id = item.Id,
            //        Description = item.Description,
            //        StateOfUrgent = item.StateOfUrgent,
            //        CreatedTime = item.CreatedTime,
            //        Title = item.Title,
            //        IsDone = item.IsDone,
            //        StateOfUrgentId = item.StateOfUrgentId
            //    };
            //    models.Add(model);
            //}
            return View(_mapper.Map<List<MyTaskListDto>>(await _myTaskService.GetUnDoneStatesofUrgent()));
        }
        public IActionResult Add()
        {
            TempData["Active"] = "MyTask";
            ViewBag.States = new SelectList(_stateOfUrgentService.GetAll(), "Id", "Type");
            return View(new MyTaskAddDto());
        }
        [HttpPost]
        public IActionResult Add(MyTaskAddDto model)
        {
            if (ModelState.IsValid)
            {
                _myTaskService.Add(new MyTask()
                {
                    Title = model.Title,
                    Description = model.Description,
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
            //var model = new MyTaskUpdateVievModel
            //{
            //    Id = task.Id,
            //    StateOfUrgentId = task.StateOfUrgentId,
            //    Description = task.Description,
            //    Title = task.Title
            //};
            ViewBag.State = new SelectList(_stateOfUrgentService.GetAll(), "Id", "Type", task.StateOfUrgentId);
            return View(_mapper.Map<MyTaskUpdateDto>(task));
        }
        [HttpPost]
        public IActionResult Edit(MyTaskUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _myTaskService.Edit(new MyTask()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Title,
                    StateOfUrgentId = model.StateOfUrgentId
                });
                return RedirectToAction(nameof(Index));
            }
            //If Validation comes fail viewbag turn null thats why should writes here!
            ViewBag.State = new SelectList(_stateOfUrgentService.GetAll(), "Id", "Type", model.StateOfUrgentId);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _myTaskService.Delete(new MyTask { Id = id });
            return Json(null);
        }
    }
}
