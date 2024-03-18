using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? SKU { get; set; }
        public string? Brand { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateofEntry { get; set; } = DateTime.Now;
    }
}
