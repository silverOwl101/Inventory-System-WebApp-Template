using Inventory_System_Template_Web_App.Claims;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }
        public required string UserId { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
