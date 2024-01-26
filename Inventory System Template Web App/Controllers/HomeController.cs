using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDBContext _applicationDBContext;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager, ApplicationDBContext applicationDBContext)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDBContext = applicationDBContext;
        }

        public IActionResult Index()
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                bool passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    TempData["Error"] = "Wrong credentials. Please, try again";
                    return View(loginViewModel);
                }                
            }
            TempData["Error"] = "Wrong credentials. Please, try again";
            return View(loginViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}