using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface ISystemUserRepository
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<IEnumerable<IdentityRole>> GetAllRoles();
        Task<IEnumerable<IdentityRole>> GetAllRolesAsNoTracking();        
        Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRoles();        
        Task<IdentityUserRole<string>> GetUserRole(string id);
        Task<IdentityUserRole<string>> GetUserRoleAsNoTracking(string id);
        public string State(object obj);       
        Task<AppUser> GetByIdAsync(string id);
        Task<AppUser> GetByIdAsyncNoTracking(string id);
        Task<bool> Add(AppUser account);
        Task<bool> Update(AppUser account);
        Task<bool> Delete(AppUser account);
        Task<bool> Save();
    }
}
