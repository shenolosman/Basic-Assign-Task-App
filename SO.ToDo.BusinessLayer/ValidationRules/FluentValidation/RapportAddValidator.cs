using FluentValidation;
using SO.ToDo.DTO.DTOs.RapportDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class RapportAddValidator : AbstractValidator<RapportAddDto>
    {
        public RapportAddValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Title cant be empty");
            RuleFor(x => x.Details).NotNull().WithMessage("Details cant be empty");
        }
    }
}
