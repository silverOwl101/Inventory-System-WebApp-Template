using Inventory_System_Template_Web_App.Models;

namespace Inventory_System_Template_Web_App.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetByIdAsync(string id);
        Task<Item> GetByIdAsyncAsNoTraking(string id);
        Task<bool> Add(Item item);
        Task<bool> Update(Item item);
        Task<bool> Delete(Item item);
        Task<bool> Save();
    }
}
