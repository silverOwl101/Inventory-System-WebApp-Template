using CloudinaryDotNet.Actions;
using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System_Template_Web_App.Repository
{
    public class RoleRepository : IRolesRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDBContext _context;

        public RoleRepository(RoleManager<IdentityRole> roleManager, ApplicationDBContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<bool> Add(IdentityRole role)
        {
            var addRole = await _roleManager.CreateAsync(role);
            return addRole.Succeeded;
        }

        public async Task<bool> Delete(IdentityRole role)
        {
            var deleteRole = await _roleManager.DeleteAsync(role);
            return deleteRole.Succeeded;
        }

        public async Task<bool> Update(IdentityRole role)
        {
            var updateRole = await _roleManager.UpdateAsync(role);
            return updateRole.Succeeded;
        }

        public async Task<IEnumerable<IdentityRole>> GetAll()
        {
            var GetAllRoles = await _context.Roles.ToListAsync();
            return GetAllRoles;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllAsNoTracking()
        {
            var GetAllRoles = await _context.Roles.AsNoTracking().ToListAsync();
            return GetAllRoles;
        }

        public async Task<IdentityRole> GetByIdAsync(IdentityRole role)
        {
            var getRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == role.Id);
            return getRole ?? new IdentityRole() { Id = string.Empty };
        }
    }
}
