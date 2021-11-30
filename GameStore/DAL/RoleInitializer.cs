using System;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminEmail = "admin@gmail.com";
            const string password = "12345";
            const string name = "admin";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByNameAsync("manager") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("manager"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User() { Email = adminEmail, UserName = name };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
                Console.WriteLine("Test");
            }
        }
    }
}