using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Application.DTOs.Inventory.Product;

namespace SmartPOS.Application.Interfaces.Iservices.Inventory
{
    public interface IProductVariantService
    {
        Task<IEnumerable<ProductVariantDto>> GetAllAsync();

        Task<ProductVariantDto?> GetByIdAsync(Guid id);

        Task<ProductVariantDto> CreateAsync(CreateProductVariantDto dto);

        Task<bool> UpdateAsync(UpdateProductVariantDto dto);

        Task<bool> DeleteAsync(Guid id);
    }
}
