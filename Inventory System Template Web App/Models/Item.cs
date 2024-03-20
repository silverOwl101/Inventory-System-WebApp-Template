using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.Models
{
    public class Item
    {
        [Key]
        public Guid? Guid { get; set; }
        public string? Id { get; set; }
        public required string Sku { get; set; }
        public required string BrandName { get; set; }
        public required string ProductName { get; set; }
        public required int Price { get; set; }
        public required string Category { get; set; }
        public required int Quantity { get; set; }
        public required string Image { get; set; }
        public required bool InStock { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
