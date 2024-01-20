﻿using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Inventory_System_Template_Web_App.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "follup@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "JohnHaroldExxxcube",
                        Email = adminUserEmail,
                        EmailConfirmed = true                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true                        
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {                
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();

                //if (!context.Accounts.Any())
                //{
                //    context.Accounts.AddRange(new List<Account>()
                //    {
                //        new Account()
                //        {
                //            Guid = Guid.NewGuid(),
                //            Id = "1199-2024",
                //            AccountName = "John",
                //            AccountPass = "eee",
                //            DateCreated = DateTime.Now,
                //            LastUpdated = DateTime.Now                            
                //         },
                //        new Account()
                //        {
                //            Guid = Guid.NewGuid(),
                //            Id = "1200-2024",
                //            AccountName = "Harold",
                //            AccountPass = "aaa",
                //            DateCreated = DateTime.Now,
                //            LastUpdated = DateTime.Now
                //         },
                //        new Account()
                //        {
                //            Guid = Guid.NewGuid(),
                //            Id = "1300-2024",
                //            AccountName = "Example",
                //            AccountPass = "www",
                //            DateCreated = DateTime.Now,
                //            LastUpdated = DateTime.Now
                //         }
                //    });
                //    context.SaveChanges();
                //}
            }
        }
    }
}
