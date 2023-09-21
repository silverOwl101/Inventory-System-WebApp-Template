using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.Models
{
    public class User
    {
        [Key]
        public required Guid Guid { get; set; }
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Gender { get; set; }
        public required string EmailAddress { get; set; }
        public required int PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required DateTime DateCreated { get; set; }
        public required DateTime LastUpdated { get; set; }
    }
}
