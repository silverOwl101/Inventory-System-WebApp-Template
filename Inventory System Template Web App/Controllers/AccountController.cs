using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class AccountController : Controller
    {        
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;            
        }
        public async Task<IActionResult> Index() // Controller
        {
            var account = await _accountRepository.GetAll(); // Model
            return View(account); // View

            //// Example of Deferred Execution https://www.tutorialsteacher.com/linq/linq-deferred-execution
            //var account = _context.Accounts.ToList(); // Model
            //return View(account); // View
        }
        public IActionResult Detail()
        {            
            return View();
        }
    }
}
