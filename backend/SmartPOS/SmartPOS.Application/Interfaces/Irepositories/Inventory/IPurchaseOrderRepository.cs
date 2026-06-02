using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Inventory;

public interface IPurchaseOrderRepository
{
    Task<IEnumerable<PurchaseOrder>> GetAllAsync();

    Task<PurchaseOrder?> GetByIdAsync(Guid id);

    Task AddAsync(PurchaseOrder order);

    Task UpdateAsync(PurchaseOrder order);

    Task DeleteAsync(PurchaseOrder order);

    Task ReceiveAsync(PurchaseOrder order);
}