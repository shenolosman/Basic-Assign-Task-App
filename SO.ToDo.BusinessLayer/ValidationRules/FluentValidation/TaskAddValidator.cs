using FluentValidation;
using SO.ToDo.DTO.DTOs.TaskDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class TaskAddValidator : AbstractValidator<MyTaskAddDto>
    {
        public TaskAddValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title field can't be empty");
            RuleFor(x => x.StateOfUrgentId).ExclusiveBetween(1, int.MaxValue).WithMessage("Please select state from list!");
        }
    }
}
