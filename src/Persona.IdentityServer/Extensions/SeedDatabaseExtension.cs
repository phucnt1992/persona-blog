using System;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persona.IdentityServer.Configurations;
using Persona.IdentityServer.Models;
using Persona.IdentityServer.Persistence;

namespace Persona.IdentityServer.Extensions
{
    public static class SeedDatabaseExtension
    {
        public static async Task SeedIdentityDatabaseAsync(this IHost host)
        {
            using (var serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                await serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                await context.Database.MigrateAsync();

                if (!await context.Clients.AnyAsync())
                {
                    foreach (var client in Config.Clients)
                    {
                        await context.Clients.AddAsync(client.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }

                if (!await context.IdentityResources.AnyAsync())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        await context.IdentityResources.AddAsync(resource.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }

                if (!await context.ApiResources.AnyAsync())
                {
                    foreach (var resource in Config.ApiResources)
                    {
                        await context.ApiResources.AddAsync(resource.ToEntity());
                    }
                    await context.SaveChangesAsync();
                }
            }
        }

        public static async Task SeedSuperAdminAccountAsync(this IHost host)
        {
            using (var serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await context.Database.MigrateAsync();

                if (!await context.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = "Super Admin" });
                    await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                    await roleManager.CreateAsync(new IdentityRole { Name = "User" });
                }

                if (!await context.Users.AnyAsync())
                {
                    await userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "sa",
                        Email = "phucnt1992@outlook.com",
                        EmailConfirmed = true,
                        FirstName = "Phuc",
                        LastName = "Nguyen",
                        PhoneNumber = "+84944065806",
                        PhoneNumberConfirmed = true
                    }, "P@ssw0rd");
                    var account = await userManager.FindByNameAsync("sa");

                    await userManager.AddToRoleAsync(account, "Super Admin");
                }
            }
        }
    }
}
