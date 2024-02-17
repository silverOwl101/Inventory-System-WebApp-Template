using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class SystemUserController : Controller
    {
        private readonly ISystemUserRepository _systemUserRepo;
        private readonly UserManager<AppUser> _userManager;

        public SystemUserController(ISystemUserRepository systemUserRepo, UserManager<AppUser> userManager)
        {
            _systemUserRepo = systemUserRepo;
            _userManager = userManager;
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
                    NickName = item.NickName,
                    Email = item.Email,
                    RoleId = roleId,
                    Role = roleName
                };
                appUserList.Add(viewModel);
            }

            return View(appUserList);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AppUserViewModel viewModel = new AppUserViewModel();
            var user = _systemUserRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            viewModel.NickName = user.Result.NickName;
            viewModel.Email = user.Result.Email;
            var userRoles = await _systemUserRepo.GetAllUserRoles();
            var roles = await _systemUserRepo.GetAllRoles();
            var role = await _systemUserRepo.GetUserRole(user.Result.Id);
            viewModel.RoleId = role != null ? role.RoleId : null;
            var roleList = roles.Select(x => new SelectListItem
            {
                Text = x.Name!.ToUpper(),
                Value = x.Id
            });
            viewModel.RoleList = roleList;

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppUserViewModel userViewModel)
        {            
            var getAllRoles = await _systemUserRepo.GetAllRoles();
            if (ModelState.IsValid)
            {
                var appUser = await _systemUserRepo.GetByIdAsync(userViewModel.Id!);
                if (appUser == null)
                {
                    return NotFound();
                }

                var userRole = await _systemUserRepo.GetUserRole(appUser.Id);
                if (userRole != null)
                {
                    if (!string.IsNullOrEmpty(userRole.RoleId.ToString()) && !string.IsNullOrEmpty(userRole.UserId.ToString()))
                    {
                        var previousRoleName = getAllRoles.Where(u => u.Id == userRole.RoleId).Select(e => e.Name).FirstOrDefault();
                        await _userManager.RemoveFromRoleAsync(appUser, previousRoleName!);
                    }

                    await _userManager.AddToRoleAsync(appUser, getAllRoles.FirstOrDefault(u => u.Id == userViewModel.RoleId)!.Name!);
                    await _systemUserRepo.Save();
                }

                if (userViewModel.NickName != null && !string.IsNullOrEmpty(userViewModel.NickName.ToString()))
                {
                    appUser.NickName = userViewModel.NickName;
                }
                await _systemUserRepo.Update(appUser);  
                
                return RedirectToAction(nameof(Index));
            }
            var roleList = getAllRoles.Select(x => new SelectListItem
            {
                Text = x.Name!.ToUpper(),
                Value = x.Id
            });
            userViewModel.RoleList = roleList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _systemUserRepo.GetByIdAsync(id);
            if (user != null)
            {
                await _systemUserRepo.Delete(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
