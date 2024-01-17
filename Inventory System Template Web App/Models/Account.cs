using Inventory_System_Template_Web_App.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.Models
{
    public class Account
    {
        [Key]
        public required Guid Guid { get; set; }
        public required string Id { get; set; }
        public required string AccountName { get; set; }
        [DataType(DataType.Password)]
        public required string AccountPass { get; set; }
        public required string Image { get; set; }
        public required DateTime DateCreated { get; set; }
        public required DateTime LastUpdated { get; set; }

    }
}
