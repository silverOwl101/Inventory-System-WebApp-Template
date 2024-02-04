using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
