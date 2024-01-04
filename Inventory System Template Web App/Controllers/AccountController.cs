using Inventory_System_Template_Web_App.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _context;
        public AccountController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index() // Controller
        {
            // Example of Deferred Execution https://www.tutorialsteacher.com/linq/linq-deferred-execution
            var account = _context.Accounts.ToList(); // Model
            return View(account); // View
        }
    }
}
