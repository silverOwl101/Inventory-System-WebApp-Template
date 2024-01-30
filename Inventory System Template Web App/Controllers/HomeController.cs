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

        public IActionResult Index()
        {            
            return View();
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