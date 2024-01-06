using Inventory_System_Template_Web_App.Models;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetByIdAsync(string id);
        bool Add(Account account);
        bool Update(Account account);
        bool Delete(Account account);
        bool Save();
    }
}
