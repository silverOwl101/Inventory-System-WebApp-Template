using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class AppUserViewModel
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? NickName { get; set; }
        public string? Role { get; set; }
        public IEnumerable<SelectListItem>? RoleList { get; set; }
        public string? RoleId { get; set; }
    }
}
