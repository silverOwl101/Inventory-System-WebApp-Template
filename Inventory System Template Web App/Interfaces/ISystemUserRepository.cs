using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface ISystemUserRepository
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<IEnumerable<IdentityRole>> GetAllRoles();        
        Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRoles();
        Task<IdentityUserRole<string>> GetUserRole(string id);
        Task<AppUser> GetByIdAsync(string id);        
        Task<bool> Add(AppUser account);
        Task<bool> Update(AppUser account);
        Task<bool> Delete(AppUser account);
        Task<bool> Save();
    }
}
