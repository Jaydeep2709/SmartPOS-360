using SmartPOS.Application.DTOs.Inventory.Supplier;

namespace SmartPOS.Application.Interfaces.IServices.Inventory;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDto>> GetAllAsync();

    Task<SupplierDto?> GetByIdAsync(Guid id);

    Task<SupplierDto> CreateAsync(CreateSupplierDto dto);

    Task<bool> UpdateAsync(UpdateSupplierDto dto);

    Task<bool> DeleteAsync(Guid id);
}