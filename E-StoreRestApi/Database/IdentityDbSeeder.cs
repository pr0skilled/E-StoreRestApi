using System;
using System.Linq;
using System.Threading.Tasks;
using E_StoreRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity;

namespace E_StoreRestApi.Database
{
    public class IdentityDbSeeder
    {
        public static void Seed(EStoreIdentityDbContext dbContext,
                              RoleManager<IdentityRole> roleManager,
                              UserManager<User> userManager)
        {
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }
        }

        private static async Task CreateUsers(
            EStoreIdentityDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {


            if (!await roleManager.RoleExistsAsync(UserRole.Administrator.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.Administrator.ToString()));
            }
            if (!await roleManager.RoleExistsAsync(UserRole.RegisteredUser.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.RegisteredUser.ToString()));
            }

            var userAdmin = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Oleksandr Makhovoi",
                UserName = "pr0skilled",
                Email = "admin@gmail.com"
            };
            if (await userManager.FindByNameAsync(userAdmin.UserName) == null)
            {
                await userManager.CreateAsync(userAdmin, "Passw0rd*");
                await userManager.AddToRoleAsync(userAdmin, UserRole.Administrator.ToString());
                await userManager.AddToRoleAsync(userAdmin, UserRole.RegisteredUser.ToString());
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
