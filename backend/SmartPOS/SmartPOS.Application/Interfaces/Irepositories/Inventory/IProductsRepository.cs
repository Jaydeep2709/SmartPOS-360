using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Inventory;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task<Product?> GetBySkuAsync(string sku);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}