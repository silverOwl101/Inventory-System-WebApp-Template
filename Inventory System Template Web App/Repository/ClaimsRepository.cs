using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Inventory_System_Template_Web_App.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public ClaimsRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Add(AppUser user, IEnumerable<Claim> claims)
        {
            var addUser = await _userManager.AddClaimsAsync(user, claims);
            return addUser.Succeeded;
        }

        public async Task<bool> Delete(AppUser user, IEnumerable<Claim> claims)
        {
            var removeUser = await _userManager.RemoveClaimsAsync(user, claims);
            return removeUser.Succeeded;
        }

        public async Task<AppUser?> FindUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IList<Claim>> GetClaims(AppUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            return claims;
        }                

        public Task<bool> Update(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
