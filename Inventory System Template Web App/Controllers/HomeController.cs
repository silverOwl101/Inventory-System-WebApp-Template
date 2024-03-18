using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
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
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager, ApplicationDBContext applicationDBContext,
                              IEmailService emailService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDBContext = applicationDBContext;
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult Index(string? returnUrl = null)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Product");
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
                    return RedirectToAction("Index", "Product");
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
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
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email!);
                if (user == null)
                {
                    return RedirectToAction("ForgotPassword");
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account",
                                            new { userId = user.Id, code = code! },
                                            protocol: HttpContext.Request.Scheme);
                await _emailService.SendEmailAsync(forgotPasswordViewModel.Email!, "Reset Email Confirmation",
                                                   "Please reset email by going to this " +
                                                   "<a href=\"" + callbackUrl + "\">link</a>");
                return RedirectToAction("ForgotPasswordConfirmation");
            }
            return View(forgotPasswordViewModel);
        }
        public IActionResult ForgotPasswordConfirmation()
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