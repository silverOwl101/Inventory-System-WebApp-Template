using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Migrations;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class SystemUserController : Controller
    {
        ISystemUserRepository _systemUserRepo;
        public SystemUserController(ISystemUserRepository systemUserRepo)
        {
            _systemUserRepo = systemUserRepo;
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            List<AppUserViewModel> appUserList = new List<AppUserViewModel>();
            string roleName = string.Empty;
            string roleId = string.Empty;
            var user = await _systemUserRepo.GetAll();
            var roles = await _systemUserRepo.GetAllRoles();

            foreach (var item in user)
            {
                var role = await _systemUserRepo.GetUserRole(item.Id);
                if (!string.IsNullOrEmpty(role.UserId) && !string.IsNullOrEmpty(role.RoleId))
                {
                    roleName = roles.FirstOrDefault(x => x.Id == role.RoleId)!.Name!.ToUpper();
                    roleId = role.RoleId;
                }
                else
                {
                    roleName = "None";
                    roleId = "None";
                }
                AppUserViewModel viewModel = new AppUserViewModel
                {
                    Id = item.Id,
                    Username = item.UserName,
                    Email = item.Email,
                    RoleId = roleId,
                    Role = roleName
                };
                appUserList.Add(viewModel);
            }
            
            return View(appUserList);
        }
    }
}
