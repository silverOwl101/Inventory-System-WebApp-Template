using Inventory_System_Template_Web_App.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.Models
{
    public class Account
    {
        [Key]
        public required Guid Guid { get; set; } = Guid.NewGuid();
        public required string Id { get; set; } = Generators.NewId();
        public required string AccountName { get; set; }
        [DataType(DataType.Password)]
        public required string AccountPass { get; set; }
        public required DateTime DateCreated { get; set; } = DateTime.Now;
        public required DateTime LastUpdated { get; set; } = DateTime.Now;

    }
}
