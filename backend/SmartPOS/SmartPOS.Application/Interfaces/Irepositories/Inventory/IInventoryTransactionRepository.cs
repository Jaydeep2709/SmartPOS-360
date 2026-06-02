using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Inventory;

public interface IInventoryTransactionRepository
{
    Task<IEnumerable<InventoryTransaction>> GetAllAsync();

    Task<InventoryTransaction?> GetByIdAsync(Guid id);

    Task AddAsync(InventoryTransaction transaction);

    Task UpdateAsync(InventoryTransaction transaction);

    Task DeleteAsync(InventoryTransaction transaction);
}