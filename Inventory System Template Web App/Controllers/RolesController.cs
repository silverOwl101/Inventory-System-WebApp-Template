using Inventory_System_Template_Web_App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class RolesController : Controller
    {
        private readonly ISystemUserRepository _systemUserRepository;        

        public RolesController(ISystemUserRepository systemUserRepository)
        {
            _systemUserRepository = systemUserRepository;            
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await _systemUserRepository.GetAllRoles();
            return View(roles);
        }
    }
}
