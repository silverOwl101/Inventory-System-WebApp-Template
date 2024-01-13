using CloudinaryDotNet;
using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.Utilities;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPhotoService _photoService;

        public AccountController(IAccountRepository accountRepository,IPhotoService photoService)
        {
            _accountRepository = accountRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(AccountViewModel accountVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(accountVM.Image);
                var account = new Models.Account
                {
                    Guid = Guid.NewGuid(),
                    Id = Generators.NewId(),
                    AccountName = accountVM.AccountName,
                    AccountPass = accountVM.AccountPass,
                    Image = result.Url.ToString(),
                    DateCreated = DateTime.Now,
                    LastUpdated = DateTime.Now
                };
                await _accountRepository.Add(account);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("","Photo upload failed");

            return View(accountVM);
        }
    }
}
