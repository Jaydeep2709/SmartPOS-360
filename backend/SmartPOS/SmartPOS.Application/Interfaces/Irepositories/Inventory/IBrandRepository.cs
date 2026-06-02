using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Inventory;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync();

    Task<Brand?> GetByIdAsync(Guid id);

    Task AddAsync(Brand brand);

    Task UpdateAsync(Brand brand);

    Task DeleteAsync(Brand brand);
}