using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class AccountViewModel
    {
        public required string AccountName { get; set; }        
        public required string AccountPass { get; set; }
        public required IFormFile Image { get; set; }   
    }
}
