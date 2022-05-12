using Microsoft.Extensions.DependencyInjection;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Concrete;
using SO.ToDo.BusinessLayer.Interfaces;

namespace SO.ToDo.BusinessLayer.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMyTaskService, MyTaskManager>();
            services.AddScoped<IRapportService, RapportManager>();
            services.AddScoped<IStateOfUrgentService, StateOfUrgentManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IMyTaskDAL, EfMyTaskRepository>();
            services.AddScoped<IStateOfUrgentDal, EfStateOfUrgentRepository>();
            services.AddScoped<IRapportDal, EfRapportRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();
        }
    }
}
