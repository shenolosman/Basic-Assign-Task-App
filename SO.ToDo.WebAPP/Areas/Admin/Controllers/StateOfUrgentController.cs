using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP.Areas.Admin.Models;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StateOfUrgentController : Controller
    {
        private readonly IStateOfUrgentService _stateOfUrgentService;

        public StateOfUrgentController(IStateOfUrgentService stateOfUrgentService)
        {
            _stateOfUrgentService = stateOfUrgentService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "StateOfUrgent";
            var list = _stateOfUrgentService.GetAll();

            var model = new List<StateOfUrgentListViewModel>();
            foreach (var item in list)
            {
                var modelItem = new StateOfUrgentListViewModel
                {
                    Id = item.Id,
                    Type = item.Type
                };
                model.Add(modelItem);
            }
            return View(model);
        }

        public IActionResult Add()
        {
            TempData["Active"] = "StateOfUrgent";
            return View(new StateOfUrgentAddViewModel());
        }
        [HttpPost]
        public IActionResult Add(StateOfUrgentAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _stateOfUrgentService.Add(new StateOfUrgent() { Type = model.Type });
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            TempData["Active"] = "StateOfUrgent";
            var state = _stateOfUrgentService.GetById(id);
            var model = new StateOfUrgentUpdateViewModel { Id = state.Id, Type = state.Type };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StateOfUrgentUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _stateOfUrgentService.Edit(new StateOfUrgent()
                {
                    Id = model.Id,
                    Type = model.Type
                });
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
