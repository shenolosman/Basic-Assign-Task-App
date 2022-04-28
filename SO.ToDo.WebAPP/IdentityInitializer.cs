using Microsoft.AspNetCore.Identity;
using SO.ToDo.Entities.Concrete;

namespace SO.ToDo.WebAPP
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("Admin");
            if (adminUser == null)
            {
                AppUser userAdmin = new AppUser
                {
                    Name = "Admin",
                    Surname = "Admin",
                    UserName = "Admin",
                    Email = "admin@mail.com"
                };
                await userManager.CreateAsync(userAdmin, "Passw0rd!");
                await userManager.AddToRoleAsync(userAdmin, "Admin");
            }
        }
    }
}
