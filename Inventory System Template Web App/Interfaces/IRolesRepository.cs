using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface IRolesRepository
    {        
        Task<IEnumerable<IdentityRole>> GetAll();
        Task<IEnumerable<IdentityRole>> GetAllAsNoTracking();
        Task<IdentityRole> GetByIdAsync(string id);
        Task<bool> Add(IdentityRole role);
        Task<bool> Update(IdentityRole role);
        Task<bool> Delete(IdentityRole role);
        Task<bool> isExist(string name);
        Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRoleusingRoleId(string id);

    }
}
