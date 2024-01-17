using Inventory_System_Template_Web_App.Models;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAll();
        Task<Account> GetByIdAsync(string id);
        Task<Account> GetByIdAsyncAsNoTraking(string id);        
        Task<bool> Add(Account account);
        Task<bool> Update(Account account);
        Task<bool> Delete(Account account);
        Task<bool> Save();
    }
}
