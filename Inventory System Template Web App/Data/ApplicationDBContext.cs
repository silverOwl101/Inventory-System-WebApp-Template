using Inventory_System_Template_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System_Template_Web_App.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
