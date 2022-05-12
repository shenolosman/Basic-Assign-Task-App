using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Concrete;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.BusinessLayer.ValidationRules.FluentValidation;
using SO.ToDo.DTO.DTOs.AppUserDtos;
using SO.ToDo.DTO.DTOs.RapportDtos;
using SO.ToDo.DTO.DTOs.StateOfUrgentDtos;
using SO.ToDo.DTO.DTOs.TaskDtos;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP;
using SO.ToDo.WebAPP.Mapping.AutoMapperProfile;
using SO.ToDo.WebAPP.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToDoContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ToDoContext>();

builder.Services.AddScoped<IMyTaskService, MyTaskManager>();
builder.Services.AddScoped<IRapportService, RapportManager>();
builder.Services.AddScoped<IStateOfUrgentService, StateOfUrgentManager>();
builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IFileService, FileManager>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

builder.Services.AddScoped<IMyTaskDAL, EfMyTaskRepository>();
builder.Services.AddScoped<IStateOfUrgentDal, EfStateOfUrgentRepository>();
builder.Services.AddScoped<IRapportDal, EfRapportRepository>();
builder.Services.AddScoped<IAppUserDal, EfAppUserRepository>();
builder.Services.AddScoped<INotificationDal, EfNotificationRepository>();
builder.Services.AddScoped<GeneralHandler>();

builder.Services.AddAutoMapper(typeof(MapProfile));

//FluentValidator
builder.Services.AddTransient<IValidator<StateOfUrgentAddDto>, StateOfUrgentAddValidator>();
builder.Services.AddTransient<IValidator<StateOfUrgentUpdateDto>, StateOfUrgentUpdateValidator>();
builder.Services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
builder.Services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
builder.Services.AddTransient<IValidator<MyTaskUpdateDto>, MyTaskUpdateValidator>();
builder.Services.AddTransient<IValidator<RapportAddDto>, RapportAddValidator>();
builder.Services.AddTransient<IValidator<RapportUpdateDto>, RapportUpdateValidator>();
builder.Services.AddTransient<IValidator<MyTaskAddDto>, TaskAddValidator>();

//Cookie
builder.Services.ConfigureApplicationCookie(o =>
{
    o.Cookie.Name = "TodoAppCookie";
    o.Cookie.SameSite = SameSiteMode.Strict;
    o.Cookie.HttpOnly = true;
    o.ExpireTimeSpan = TimeSpan.FromDays(30);
    o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    o.LoginPath = "/Home/Index";
});

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddFluentValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<AppRole>>();
    IdentityInitializer.SeedData(userManager, roleManager).Wait();
}

app.Run();
