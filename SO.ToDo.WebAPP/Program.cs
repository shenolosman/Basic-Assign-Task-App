using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Contexts;
using SO.ToDo.BusinessLayer.DiContainer;
using SO.ToDo.Entities.Concrete;
using SO.ToDo.WebAPP;
using SO.ToDo.WebAPP.CustomCollectionExtensions;
using SO.ToDo.WebAPP.Mapping.AutoMapperProfile;
using SO.ToDo.WebAPP.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ToDoContext>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ToDoContext>();

//Custom dependencies
builder.Services.AddContainerWithDependencies();
builder.Services.AddScoped<GeneralHandler>();

builder.Services.AddAutoMapper(typeof(MapProfile));

//FluentValidator
builder.Services.AddValidatorContainer();

//Cookie
builder.Services.AddCookieContainer();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddFluentValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseStatusCodePages("/Home/StatusCode", "?code={0}");

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
