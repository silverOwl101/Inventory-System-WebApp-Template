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
        public bool Add(Account account)
        {
            _context.Add(account);
            return Save();
        }
        public bool Update(Account account)
        {
            _context.Update(account);
            return Save();
        }
        public bool Delete(Account account)
        {
            _context.Remove(account);
            return Save();
        }
        public async Task<IEnumerable<Account>> GetAll()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> GetByIdAsync(string id)
        {            
            return await _context.Accounts.FirstOrDefaultAsync(i => i.Id == id) ?? throw new ArgumentNullException();
        }
        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }        
    }
}
