using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.Utilities;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account account)
        {                            
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            
            _accountRepository.Add(account);
            return RedirectToAction("Index");
        }
    }
}
