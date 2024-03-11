using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface IClaimsRepository
    {        
        Task<AppUser?> FindUser(string id);
        Task<IList<Claim>> GetClaims(AppUser user);
        Task<bool> Add(AppUser user, IEnumerable<Claim> claims);
        Task<bool> Update(AppUser user);
        Task<bool> Delete(AppUser user, IEnumerable<Claim> claims);                
    }
}
