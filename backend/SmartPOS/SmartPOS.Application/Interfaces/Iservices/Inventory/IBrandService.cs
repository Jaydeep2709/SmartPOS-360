using SmartPOS.Application.DTOs.Inventory.Brand;

namespace SmartPOS.Application.Interfaces.IServices.Inventory;

public interface IBrandService
{
    Task<IEnumerable<BrandDto>> GetAllAsync();

    Task<BrandDto?> GetByIdAsync(Guid id);

    Task<BrandDto> CreateAsync(CreateBrandDto dto);

    Task<bool> UpdateAsync(UpdateBrandDto dto);

    Task<bool> DeleteAsync(Guid id);
}