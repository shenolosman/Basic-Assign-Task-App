using FluentValidation;
using SO.ToDo.DTO.DTOs.StateOfUrgentDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class StateOfUrgentUpdateValidator : AbstractValidator<StateOfUrgentUpdateDto>
    {
        public StateOfUrgentUpdateValidator()
        {
            RuleFor(x => x.Type).NotNull().WithMessage("You can't leave empty this field");
        }
    }
}
