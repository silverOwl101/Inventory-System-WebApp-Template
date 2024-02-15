using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System_Template_Web_App.Repository
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly ApplicationDBContext _context;
        public SystemUserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<bool> Add(AppUser account)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Update(AppUser account)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(AppUser account)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            var userList = _context.AppUsers.ToListAsync();
            return await userList;
        }

        public async Task<IEnumerable<IdentityUserRole<string>>> GetAllUserRoles()
        {
            var userRole = _context.UserRoles.ToListAsync();
            return await userRole;
        }

        public async Task<IdentityUserRole<string>> GetUserRole(string id)
        {
            var userRole = _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == id);
            return await userRole ?? new IdentityUserRole<string>() { UserId = string.Empty, RoleId = string.Empty };
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            var roles = _context.Roles.ToListAsync();
            return await roles;
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            var user = _context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            return await user ?? new AppUser() { };
        }

        public async Task<bool> Save()
        {
            int save = await _context.SaveChangesAsync();
            return save > 0 ? true : false;
        }
    }
}
