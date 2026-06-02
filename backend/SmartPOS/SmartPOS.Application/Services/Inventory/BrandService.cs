using SmartPOS.Application.DTOs.Inventory.Brand;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;

    public BrandService(IBrandRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BrandDto>> GetAllAsync()
    {
        var brands = await _repository.GetAllAsync();

        return brands.Select(x => new BrandDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        });
    }

    public async Task<BrandDto?> GetByIdAsync(Guid id)
    {
        var brand = await _repository.GetByIdAsync(id);

        if (brand == null)
            return null;

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description
        };
    }

    public async Task<BrandDto> CreateAsync(CreateBrandDto dto)
    {
        var brand = new Brand
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description
        };

        await _repository.AddAsync(brand);

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            Description = brand.Description
        };
    }

    public async Task<bool> UpdateAsync(UpdateBrandDto dto)
    {
        var brand = await _repository.GetByIdAsync(dto.Id);

        if (brand == null)
            return false;

        brand.Name = dto.Name;
        brand.Description = dto.Description;

        await _repository.UpdateAsync(brand);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var brand = await _repository.GetByIdAsync(id);

        if (brand == null)
            return false;

        await _repository.DeleteAsync(brand);

        return true;
    }
}