using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Repositories;
using So.ToDo.DataAccessLayer.Interfaces;
using SO.ToDo.BusinessLayer.Concrete;
using SO.ToDo.BusinessLayer.Interfaces;
using SO.ToDo.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IMyTaskService, MyTaskManager>();
builder.Services.AddScoped<IRapportService, RapportManager>();
builder.Services.AddScoped<IStateOfUrgentService, StateOfUrgentManager>();

builder.Services.AddScoped<IMyTaskDAL, EfMyTaskRepository>();
builder.Services.AddScoped<IStateOfUrgentDal, EfStateOfUrgentRepository>();
builder.Services.AddScoped<IRapportDal, EfRapportRepository>();

builder.Services.AddDbContext<ToDoContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ToDoContext>();


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.MapAreaControllerRoute("admin","Admin","Index","id");
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

app.Run();
