using Microsoft.AspNetCore.Identity;

namespace Inventory_System_Template_Web_App.Models
{
    public class AppUser : IdentityUser
    {
        public string? NickName { get; set; }
        public int? Pace { get; set; }
        public int? Milage { get; set; }
        public ICollection<Account>? Accounts { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Item>? Items { get; set; }
    }
}
