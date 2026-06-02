using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Domain.Identity.Entities;
//using SmartPOS.Infrastructure.Persistence;

namespace SmartPOS.Infrastructure.Seed;

public static class DbSeeder
{
    public static async Task SeedAdminAsync(IServiceProvider services)
    {
        var userManager =
            services.GetRequiredService<UserManager<ApplicationUser>>();

        var roleManager =
            services.GetRequiredService<RoleManager<Role>>();

        // Roles
        string[] roles =
        {
            "Admin",
            "Manager",
            "Cashier"
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new Role
                {
                    Name = role
                });
            }
        }

        // Admin User
        var adminEmail = "admin@smartpos.com";

        var adminUser =
            await userManager.Users
                .FirstOrDefaultAsync(x => x.Email == adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                FullName = "System Admin",
                UserName = "admin",
                Email = adminEmail,
                EmailConfirmed = true,
                IsActive = true
            };

            var result = await userManager.CreateAsync(
                adminUser,
                "Admin@123"
            );

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(
                    adminUser,
                    "Admin"
                );
            }
        }
    }
}