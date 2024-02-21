using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface IRolesRepository
    {        
        Task<IEnumerable<IdentityRole>> GetAll();
        Task<IEnumerable<IdentityRole>> GetAllAsNoTracking();
        Task<IdentityRole> GetByIdAsync(IdentityRole role);
        Task<bool> Add(IdentityRole role);
        Task<bool> Update(IdentityRole role);
        Task<bool> Delete(IdentityRole role);
    }
}
