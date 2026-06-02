using SmartPOS.Application.DTOs.Inventory.Product;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class ProductVariantService : IProductVariantService
{
    private readonly IProductVariantRepository _repository;

    public ProductVariantService(
        IProductVariantRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductVariantDto>> GetAllAsync()
    {
        var variants = await _repository.GetAllAsync();

        return variants.Select(x => new ProductVariantDto
        {
            Id = x.Id,
            ProductId = x.ProductId,
            VariantName = x.VariantName,
            SKU = x.SKU,
            Barcode = x.Barcode,
            SellingPrice = x.SellingPrice,
            CostPrice = x.CostPrice
        });
    }

    public async Task<ProductVariantDto?> GetByIdAsync(Guid id)
    {
        var variant = await _repository.GetByIdAsync(id);

        if (variant == null)
            return null;

        return new ProductVariantDto
        {
            Id = variant.Id,
            ProductId = variant.ProductId,
            VariantName = variant.VariantName,
            SKU = variant.SKU,
            Barcode = variant.Barcode,
            SellingPrice = variant.SellingPrice,
            CostPrice = variant.CostPrice
        };
    }

    public async Task<ProductVariantDto> CreateAsync(
        CreateProductVariantDto dto)
    {
        var variant = new ProductVariant
        {
            Id = Guid.NewGuid(),
            ProductId = dto.ProductId,
            VariantName = dto.VariantName,
            SKU = dto.SKU,
            Barcode = dto.Barcode,
            SellingPrice = dto.SellingPrice,
            CostPrice = dto.CostPrice
        };

        await _repository.AddAsync(variant);

        return new ProductVariantDto
        {
            Id = variant.Id,
            ProductId = variant.ProductId,
            VariantName = variant.VariantName,
            SKU = variant.SKU,
            Barcode = variant.Barcode,
            SellingPrice = variant.SellingPrice,
            CostPrice = variant.CostPrice
        };
    }

    public async Task<bool> UpdateAsync( UpdateProductVariantDto dto )
    {
        var variant = await _repository.GetByIdAsync(dto.Id);

        if (variant == null)
            return false;

        variant.ProductId = dto.ProductId;
        variant.VariantName = dto.VariantName;
        variant.SKU = dto.SKU;
        variant.Barcode = dto.Barcode;
        variant.SellingPrice = dto.SellingPrice;
        variant.CostPrice = dto.CostPrice;

        await _repository.UpdateAsync(variant);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var variant = await _repository.GetByIdAsync(id);

        if (variant == null)
            return false;

        await _repository.DeleteAsync(variant);

        return true;
    }
}