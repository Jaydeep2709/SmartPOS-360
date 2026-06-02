using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Inventory;

public interface IProductVariantRepository
{
    Task<IEnumerable<ProductVariant>> GetAllAsync();

    Task<ProductVariant?> GetByIdAsync(Guid id);

    Task AddAsync(ProductVariant variant);

    Task UpdateAsync(ProductVariant variant);

    Task DeleteAsync(ProductVariant variant);
}