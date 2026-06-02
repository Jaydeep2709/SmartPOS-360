//using SmartPOS.Application.DTOs.Inventory.Product;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SmartPOS.Application.DTOs.Inventory.Products;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductListDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();

        return products.Select(x => new ProductListDto
        {
            Id = x.Id,
            Name = x.Name,
            CategoryName = x.Category?.Name ?? "",
            BrandName = x.Brand?.Name ?? "",
            Description = x.Description ?? "",
            SellingPrice = x.SellingPrice,
            IsActive = x.IsActive
        });
    }

    public async Task<ProductDetailsDto?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return null;

        return new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            Barcode = product.Barcode,
            Description = product.Description,
            CategoryName = product.Category?.Name ?? "",
            BrandName = product.Brand?.Name ?? "",
            UnitName = product.Unit?.Name ?? "",
            SupplierName = product.Supplier?.Name ?? "",
            CostPrice = product.CostPrice,
            SellingPrice = product.SellingPrice,
            TaxPercentage = product.TaxPercentage,
            DiscountPercentage = product.DiscountPercentage,
            ReorderLevel = product.ReorderLevel,
            IsActive = product.IsActive
        };
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var existing = await _repository.GetBySkuAsync(dto.SKU);

        if (existing != null)
            throw new Exception("SKU already exists");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            CategoryId = dto.CategoryId,
            BrandId = dto.BrandId,
            UnitId = dto.UnitId,
            SupplierId = dto.SupplierId,
            Name = dto.Name,
            SKU = dto.SKU,
            Barcode = dto.Barcode,
            Description = dto.Description,
            CostPrice = dto.CostPrice,
            SellingPrice = dto.SellingPrice,
            TaxPercentage = dto.TaxPercentage,
            DiscountPercentage = dto.DiscountPercentage,
            ReorderLevel = dto.ReorderLevel,
            IsActive = true
        };

        await _repository.AddAsync(product);

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            Barcode = product.Barcode,
            Description = product.Description,
            CostPrice = product.CostPrice,
            SellingPrice = product.SellingPrice,
            IsActive = product.IsActive
        };
    }

    public async Task<bool> UpdateAsync(UpdateProductDto dto)
    {
        var product = await _repository.GetByIdAsync(dto.Id);

        if (product == null)
            return false;

        product.Name = dto.Name;
        product.CategoryId = dto.CategoryId;
        product.BrandId = dto.BrandId;
        product.UnitId = dto.UnitId;
        product.SupplierId = dto.SupplierId;
        product.SKU = dto.SKU;
        product.Barcode = dto.Barcode;
        product.Description = dto.Description;
        product.CostPrice = dto.CostPrice;
        product.SellingPrice = dto.SellingPrice;
        product.TaxPercentage = dto.TaxPercentage;
        product.DiscountPercentage = dto.DiscountPercentage;
        product.ReorderLevel = dto.ReorderLevel;
        product.IsActive = dto.IsActive;

        await _repository.UpdateAsync(product);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return false;

        await _repository.DeleteAsync(product);

        return true;
    }
}