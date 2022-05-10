using FluentValidation;
using SO.ToDo.DTO.DTOs.AppUserDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Please Fill Username Field!");
            RuleFor(x => x.Password).NotNull().WithMessage("Please Fill Password Field!");
        }
    }
}
