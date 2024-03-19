using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.Models
{
    public class Item
    {
        [Key]
        public required Guid Guid { get; set; }
        public required string Id { get; set; }
        public required string Sku { get; set; }
        public required string ProductName { get; set; }
        public required int Price { get; set; }
        public required string Category { get; set; }
        public required int Quantity { get; set; }
        public required string Image { get; set; }
        public required bool InStock { get; set; }
        public required DateTime DateCreated { get; set; }
    }
}
