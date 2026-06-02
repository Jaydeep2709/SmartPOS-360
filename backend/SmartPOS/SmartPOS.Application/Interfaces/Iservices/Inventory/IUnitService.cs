using SmartPOS.Application.DTOs.Inventory.Unit;

namespace SmartPOS.Application.Interfaces.IServices.Inventory;

public interface IUnitService
{
    Task<IEnumerable<UnitDto>> GetAllAsync();

    Task<UnitDto?> GetByIdAsync(Guid id);

    Task<UnitDto> CreateAsync(CreateUnitDto dto);

    Task<bool> UpdateAsync(UpdateUnitDto dto);

    Task<bool> DeleteAsync(Guid id);
}