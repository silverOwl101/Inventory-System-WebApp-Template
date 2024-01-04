using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Inventory_System_Template_Web_App.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {                
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();

                if (!context.Accounts.Any())
                {
                    context.Accounts.AddRange(new List<Account>()
                    {
                        new Account()
                        {
                            Guid = Guid.NewGuid(),
                            Id = "1199-2024",
                            AccountName = "John",
                            AccountPass = "eee",
                            DateCreated = DateTime.Now,
                            LastUpdated = DateTime.Now                            
                         },
                        new Account()
                        {
                            Guid = Guid.NewGuid(),
                            Id = "1200-2024",
                            AccountName = "Harold",
                            AccountPass = "aaa",
                            DateCreated = DateTime.Now,
                            LastUpdated = DateTime.Now
                         },
                        new Account()
                        {
                            Guid = Guid.NewGuid(),
                            Id = "1300-2024",
                            AccountName = "Example",
                            AccountPass = "www",
                            DateCreated = DateTime.Now,
                            LastUpdated = DateTime.Now
                         }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
