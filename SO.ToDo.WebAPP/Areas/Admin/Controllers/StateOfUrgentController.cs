using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.DTO.DTOs.StateOfUrgentDtos;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class StateOfUrgentController : Controller
    {
        private readonly IStateOfUrgentService _stateOfUrgentService;
        private readonly IMapper _mapper;
        public StateOfUrgentController(IStateOfUrgentService stateOfUrgentService, IMapper mapper)
        {
            _stateOfUrgentService = stateOfUrgentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "StateOfUrgent";
            //var list = _stateOfUrgentService.GetAll();

            //var model = new List<StateOfUrgentListViewModel>();
            //foreach (var item in list)
            //{
            //    var modelItem = new StateOfUrgentListViewModel
            //    {
            //        Id = item.Id,
            //        Type = item.Type
            //    };
            //    model.Add(modelItem);
            //}
            return View(_mapper.Map<List<StateOfUrgentListDto>>(_stateOfUrgentService.GetAll()));
        }
        public IActionResult Add()
        {
            TempData["Active"] = "StateOfUrgent";
            return View(new StateOfUrgentAddDto());
        }
        [HttpPost]
        public IActionResult Add(StateOfUrgentAddDto model)
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
            return View(_mapper.Map<StateOfUrgentUpdateDto>(_stateOfUrgentService.GetById(id)));
        }

        [HttpPost]
        public IActionResult Edit(StateOfUrgentUpdateDto model)
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
