using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class AddItemViewModel
    {
        public string? SKU { get; set; }
        public string? Brand { get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public required string? Category { get; set; }
        public required int Quantity { get; set; }
        public IFormFile? Image { get; set; }
    }
}
