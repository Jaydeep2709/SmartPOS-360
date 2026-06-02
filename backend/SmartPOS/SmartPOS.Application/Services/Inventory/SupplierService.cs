using SmartPOS.Application.DTOs.Inventory.Supplier;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;

    public SupplierService(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SupplierDto>> GetAllAsync()
    {
        var suppliers = await _repository.GetAllAsync();

        return suppliers.Select(x => new SupplierDto
        {
            Id = x.Id,
            Name = x.Name,
            ContactPerson = x.ContactPerson,
            Phone = x.Phone,
            Email = x.Email,
            Address = x.Address,
            GSTNumber = x.GSTNumber
        });
    }

    public async Task<SupplierDto?> GetByIdAsync(Guid id)
    {
        var supplier = await _repository.GetByIdAsync(id);

        if (supplier == null)
            return null;

        return new SupplierDto
        {
            Id = supplier.Id,
            Name = supplier.Name,
            ContactPerson = supplier.ContactPerson,
            Phone = supplier.Phone,
            Email = supplier.Email,
            Address = supplier.Address,
            GSTNumber = supplier.GSTNumber
        };
    }

    public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
    {
        var supplier = new Supplier
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            ContactPerson = dto.ContactPerson,
            Phone = dto.Phone,
            Email = dto.Email,
            Address = dto.Address,
            GSTNumber = dto.GSTNumber
        };

        await _repository.AddAsync(supplier);

        return await GetByIdAsync(supplier.Id);
    }

    public async Task<bool> UpdateAsync(UpdateSupplierDto dto)
    {
        var supplier = await _repository.GetByIdAsync(dto.Id);

        if (supplier == null)
            return false;

        supplier.Name = dto.Name;
        supplier.ContactPerson = dto.ContactPerson;
        supplier.Phone = dto.Phone;
        supplier.Email = dto.Email;
        supplier.Address = dto.Address;
        supplier.GSTNumber = dto.GSTNumber;

        await _repository.UpdateAsync(supplier);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var supplier = await _repository.GetByIdAsync(id);

        if (supplier == null)
            return false;

        await _repository.DeleteAsync(supplier);

        return true;
    }
}