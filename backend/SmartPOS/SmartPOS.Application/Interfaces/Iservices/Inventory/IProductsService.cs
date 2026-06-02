//using SmartPOS.Application.DTOs.Inventory.Product;
using SmartPOS.Application.DTOs.Inventory.Products;

namespace SmartPOS.Application.Interfaces.IServices.Inventory;

public interface IProductService
{
    Task<IEnumerable<ProductListDto>> GetAllAsync();

    Task<ProductDetailsDto?> GetByIdAsync(Guid id);

    Task<ProductDto> CreateAsync(CreateProductDto dto);

    Task<bool> UpdateAsync(UpdateProductDto dto);

    Task<bool> DeleteAsync(Guid id);
}