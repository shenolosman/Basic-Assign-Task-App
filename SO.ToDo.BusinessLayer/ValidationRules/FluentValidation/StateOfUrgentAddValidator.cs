using FluentValidation;
using SO.ToDo.DTO.DTOs.StateOfUrgentDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class StateOfUrgentAddValidator : AbstractValidator<StateOfUrgentAddDto>
    {
        public StateOfUrgentAddValidator()
        {
            RuleFor(x => x.Type).NotNull().WithMessage("You can't leave empty this field");
        }
    }
}
