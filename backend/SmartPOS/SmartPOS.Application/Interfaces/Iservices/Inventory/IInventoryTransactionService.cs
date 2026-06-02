using SmartPOS.Application.DTOs.Inventory.InventoryTransaction;

namespace SmartPOS.Application.Interfaces.IServices.Inventory;

public interface IInventoryTransactionService
{
    Task<IEnumerable<InventoryTransactionDto>> GetAllAsync();

    Task<InventoryTransactionDto?> GetByIdAsync(Guid id);

    Task<InventoryTransactionDto> CreateAsync(
        CreateInventoryTransactionDto dto);

    Task<bool> UpdateAsync(
        Guid id,
        CreateInventoryTransactionDto dto);

    Task<bool> DeleteAsync(Guid id);
}