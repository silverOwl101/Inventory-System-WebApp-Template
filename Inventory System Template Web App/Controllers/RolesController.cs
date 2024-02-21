using Inventory_System_Template_Web_App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class RolesController : Controller
    {
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(ISystemUserRepository systemUserRepository, RoleManager<IdentityRole> roleManager)
        {
            _systemUserRepository = systemUserRepository;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await _systemUserRepository.GetAllRoles();
            return View(roles);
        }
    }
}
