using Inventory_System_Template_Web_App.Claims;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Inventory_System_Template_Web_App.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly IClaimsRepository _claimsRepository;

        public ClaimsController(IClaimsRepository claimsRepository)
        {
            _claimsRepository = claimsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var user = await _claimsRepository.FindUser(id);
            if (user == null) { return NotFound(); }

            var existingUserClaims = await _claimsRepository.GetClaims(user);

            var model = new UserClaimsViewModel()
            {
                UserId = id
            };

            foreach (Claim claim in ClaimStore.claimList)
            {
                UserClaim userClaim = new UserClaim()
                {
                    ClaimType = claim.Type,
                };
                if (existingUserClaims.Any(x => x.Type == claim.Type))
                {
                    userClaim.isSelected = true;
                }
                model.Claims.Add(userClaim);
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserClaimsViewModel viewModel) 
        {
            var user = await _claimsRepository.FindUser(viewModel.UserId);
            if (user == null) { return NotFound(); }
            var claims = await _claimsRepository.GetClaims(user);
            var result = await _claimsRepository.Delete(user,claims);

            if (!result)
            {
                return View(viewModel);
            }
            result = await _claimsRepository.Add(user,viewModel.Claims.Where(c => c.isSelected)
                                            .Select(c => new Claim(c.ClaimType!, c.isSelected.ToString())));
            if (!result) 
            {
                return View(viewModel);
            }
            return RedirectToAction("Index","SystemUser");
        }
    }
}
