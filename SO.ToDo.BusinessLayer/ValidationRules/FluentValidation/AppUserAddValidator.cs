using FluentValidation;
using SO.ToDo.DTO.DTOs.AppUserDtos;

namespace SO.ToDo.BusinessLayer.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Please Fill Username Field!");
            RuleFor(x => x.Password).NotNull().WithMessage("Please Fill Password Field!");
            RuleFor(x => x.RePassword).NotNull().WithMessage("Please Fill RePassword Field!");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Please Fill Email Field!");
            RuleFor(x => x.Name).NotNull().WithMessage("Please Fill Name Field!");
            RuleFor(x => x.Surname).NotNull().WithMessage("Please Fill Surname Field!");
            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Passwords does not match!");
        }
    }
}
