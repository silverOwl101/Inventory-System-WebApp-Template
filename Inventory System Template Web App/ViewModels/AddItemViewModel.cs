using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class AddItemViewModel
    {        
        public string? Brand { get; set; }
        public string? ProductName { get; set; }
        public required int Quantity { get; set; }
        public required IFormFile Image { get; set; }
    }
}
