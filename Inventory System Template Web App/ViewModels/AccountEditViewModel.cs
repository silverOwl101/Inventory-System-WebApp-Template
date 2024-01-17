namespace Inventory_System_Template_Web_App.ViewModels
{
    public class AccountEditViewModel
    {
        public required string AccountName { get; set; }
        public required string AccountPass { get; set; }
        public IFormFile? Image { get; set; }
    }
}
