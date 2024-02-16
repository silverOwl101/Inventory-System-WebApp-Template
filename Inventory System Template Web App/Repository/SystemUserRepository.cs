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
        public async Task<bool> Add(AppUser account)
        {
            await _context.AddAsync(account);
            return await Save();
        }
        public async Task<bool> Update(AppUser account)
        {
            _context.Update(account);
            return await Save();
        }
        public async Task<bool> Delete(AppUser account)
        {
            _context.Remove(account);
            return await Save();
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
        public async Task<IdentityUserRole<string>> GetUserRoleAsNoTracking(string id)
        {
            var userRole = _context.UserRoles.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);
            return await userRole ?? new IdentityUserRole<string>() { UserId = string.Empty, RoleId = string.Empty };
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRoles()
        {
            var roles = _context.Roles.ToListAsync();
            return await roles;
        }
        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsNoTracking()
        {
            var roles = _context.Roles.AsNoTracking().ToListAsync();
            return await roles;
        }
        public async Task<AppUser> GetByIdAsync(string id)
        {
            var user = _context.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
            return await user ?? new AppUser() { };
        }
        public async Task<AppUser> GetByIdAsyncNoTracking(string id)
        {
            var user = _context.AppUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return await user ?? new AppUser() { };
        }

        public async Task<bool> Save()
        {
            int save = await _context.SaveChangesAsync();
            return save > 0 ? true : false;
        }

        public string State(object obj)
        {
            return _context.Entry(obj).State.ToString();
        }
    }
}
