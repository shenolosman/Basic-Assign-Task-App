using FluentValidation;
using SO.ToDo.DTO.DTOs.TaskDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class MyTaskUpdateValidator : AbstractValidator<MyTaskUpdateDto>
    {
        public MyTaskUpdateValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title field can't be empty");
            RuleFor(x => x.StateOfUrgentId).ExclusiveBetween(0, int.MaxValue).WithMessage("Please select state from list!");
        }
    }
}
