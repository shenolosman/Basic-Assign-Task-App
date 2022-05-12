using FluentValidation;
using SO.ToDo.BusinessLayer.ValidationRules.FluentValidation;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.DTO.DTOs.RapportDtos;
using SO.ToDo.DTO.DTOs.StateOfUrgentDtos;
using SO.ToDo.DTO.DTOs.TaskDtos;

namespace SO.ToDo.WebAPP.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddValidatorContainer(this IServiceCollection services)
        {
            services.AddTransient<IValidator<StateOfUrgentAddDto>, StateOfUrgentAddValidator>();
            services.AddTransient<IValidator<StateOfUrgentUpdateDto>, StateOfUrgentUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<MyTaskUpdateDto>, MyTaskUpdateValidator>();
            services.AddTransient<IValidator<RapportAddDto>, RapportAddValidator>();
            services.AddTransient<IValidator<RapportUpdateDto>, RapportUpdateValidator>();
            services.AddTransient<IValidator<MyTaskAddDto>, TaskAddValidator>();
        }
        public static void AddCookieContainer(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(o =>
            {
                o.Cookie.Name = "TodoAppCookie";
                o.Cookie.SameSite = SameSiteMode.Strict;
                o.Cookie.HttpOnly = true;
                o.ExpireTimeSpan = TimeSpan.FromDays(30);
                o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                o.LoginPath = "/Home/Index";
            });
        }
    }
}
