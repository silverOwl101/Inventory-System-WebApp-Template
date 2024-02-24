using CloudinaryDotNet.Actions;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Repository;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_System_Template_Web_App.Controllers
{    
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly IRolesRepository _rolesRepository;        

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;            
        }
        
        public async Task<IActionResult> Index()
        {
            var roles = await _rolesRepository.GetAll();
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> Upsert(string id)
        {
            UpsertViewModel viewModel = new UpsertViewModel();            
            if (!string.IsNullOrEmpty(id))
            {
                var user = await _rolesRepository.GetByIdAsync(id);
                viewModel.Id = user.Id;
                viewModel.Name = user.Name;
                return View(viewModel);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(IdentityRole role)
        {
            bool isExist = await _rolesRepository.isExist(role.Name!);
            if (isExist)
            {
                return RedirectToAction(nameof(Index));
            }
            if (string.IsNullOrEmpty(role.Id))
            {                
                await _rolesRepository.Add(new IdentityRole{ Name = role.Name});
            }
            else
            {
                var getRole = await _rolesRepository.GetByIdAsync(role.Id);
                if (string.IsNullOrEmpty(getRole.Id))
                {
                    return RedirectToAction(nameof(Index));
                }
                getRole.Name = role.Name;
                getRole.NormalizedName = role.Name!.ToUpper();
                var result = await _rolesRepository.Update(getRole);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var getRole = await _rolesRepository.GetByIdAsync(id);
            if (string.IsNullOrEmpty(getRole.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            var userForThisRole = await _rolesRepository.GetAllUserRoleusingRoleId(id);
            int count = userForThisRole.Count();
            if (count > 0) 
            {
                return RedirectToAction(nameof(Index));
            }
            await _rolesRepository.Delete(getRole);
            return RedirectToAction(nameof(Index));
        }
    }
}
