using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System_Template_Web_App.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Account account)
        {
            await _context.AddAsync(account);
            return await Save();
        }
        public async Task<bool> Update(Account account)
        {
            _context.Update(account);
            return await Save();
        }
        public async Task<bool> Delete(Account account)
        {
            _context.Remove(account);
            return await Save();
        }
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.OrderByDescending(x => x.DateCreated).ToListAsync();
        }
        public async Task<Account> GetByIdAsync(string id)
        {            
            return await _context.Accounts.FirstOrDefaultAsync(i => i.Id == id) ?? throw new ArgumentNullException();
        }
        public async Task<Account> GetByIdAsyncAsNoTraking(string id)
        {
            return await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id) ?? throw new ArgumentNullException();
        }
        public async Task<bool> Save()
        {
            var save = await _context.SaveChangesAsync();
            return save > 0 ? true : false;
        }        
    }
}
