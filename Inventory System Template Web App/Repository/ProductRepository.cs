using Inventory_System_Template_Web_App.Data;
using Inventory_System_Template_Web_App.Interfaces;
using Inventory_System_Template_Web_App.Models;
using Inventory_System_Template_Web_App.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Inventory_System_Template_Web_App.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Item item)
        {
            await _context.AddAsync(item);
            return await Save();
        }

        public async Task<bool> Delete(Item item)
        {
            _context.Remove(item);
            return await Save();
        }

        public async Task<bool> Update(Item item)
        {
            _context.Update(item);
            return await Save();
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items.OrderByDescending(x => x.DateCreated).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id) ?? 
                   new Item() {  
                                 Guid = Guid.Empty,
                                 Id = string.Empty,
                                 Sku = string.Empty,
                                 BrandName = string.Empty!,
                                 ProductName = string.Empty,
                                 Price = 0,
                                 Category = string.Empty,
                                 Quantity = 0,
                                 Image = string.Empty,
                                 InStock = false,
                                 DateCreated = DateTime.MinValue
                              };
        }

        public async Task<Item> GetByIdAsyncAsNoTraking(string id)
        {
            return await _context.Items.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) ??
                   new Item() {
                                Guid = Guid.Empty,
                                Id = string.Empty,
                                Sku = string.Empty,
                                BrandName = string.Empty,
                                ProductName = string.Empty,
                                Price = 0,
                                Category = string.Empty,
                                Quantity = 0,
                                Image = string.Empty,
                                InStock = false,
                                DateCreated = DateTime.MinValue
                              };
        }
                
        public async Task<bool> Save()
        {
            int result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }
    }
}
