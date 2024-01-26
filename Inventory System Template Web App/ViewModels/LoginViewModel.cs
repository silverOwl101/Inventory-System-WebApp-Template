using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string  Password { get; set; }
    }
}
