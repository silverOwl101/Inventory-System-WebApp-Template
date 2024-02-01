using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Web;

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
        [HttpGet]
        public IActionResult Index(string? returnUrl = null)
        {            
            LoginViewModel loginViewModel = new LoginViewModel();
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                loginViewModel.ReturnUrl = returnUrl ?? Url.Content("~/");
            }
            return View(loginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName!,
                                                                      loginViewModel.Password!,
                                                                      loginViewModel.RememberMe,
                                                                      lockoutOnFailure: false);
                if (result.Succeeded)
                {                    
                    return RedirectToAction("Index","Account");                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(loginViewModel);
                }
            }
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