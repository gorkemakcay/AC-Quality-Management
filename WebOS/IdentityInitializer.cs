using System;
using System.Threading.Tasks;
using QM.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using QM.Entities.Concrete.Users;

namespace Webos
{
public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("ProjectManager");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Name = "Admin"
                });
            }
            var adminUser = await userManager.FindByNameAsync("Administrator");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    FirstName = "Administrator",
                    LastName = "Arlentus",
                    UserName = "admin"
                };
                await userManager.CreateAsync(user, "1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
