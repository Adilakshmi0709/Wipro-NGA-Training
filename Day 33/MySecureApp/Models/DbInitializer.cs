using Microsoft.AspNetCore.Identity;
using MySecureApp.Models;

namespace MySecureApp.Models
{
    public class DbInitializer
    {
        public async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create roles
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create admin user
            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                FullName = "Administrator"
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create regular user
            var regularUser = new ApplicationUser
            {
                UserName = "user1",
                Email = "user1@example.com",
                FullName = "Regular User"
            };

            result = await userManager.CreateAsync(regularUser, "User@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(regularUser, "User");
            }
        }
    }
}