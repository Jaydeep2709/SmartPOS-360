using SmartPOS.Application.DTOs.Inventory.Unit;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Services.Inventory;

public class UnitService : IUnitService
{
    private readonly IUnitRepository _repository;

    public UnitService(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UnitDto>> GetAllAsync()
    {
        var units = await _repository.GetAllAsync();

        return units.Select(x => new UnitDto
        {
            Id = x.Id,
            Name = x.Name,
            ShortName = x.ShortName
        });
    }

    public async Task<UnitDto?> GetByIdAsync(Guid id)
    {
        var unit = await _repository.GetByIdAsync(id);

        if (unit == null)
            return null;

        return new UnitDto
        {
            Id = unit.Id,
            Name = unit.Name,
            ShortName = unit.ShortName
        };
    }

    public async Task<UnitDto> CreateAsync(CreateUnitDto dto)
    {
        var unit = new Unit
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            ShortName = dto.ShortName
        };

        await _repository.AddAsync(unit);

        return new UnitDto
        {
            Id = unit.Id,
            Name = unit.Name,
            ShortName = unit.ShortName
        };
    }

    public async Task<bool> UpdateAsync(UpdateUnitDto dto)
    {
        var unit = await _repository.GetByIdAsync(dto.Id);

        if (unit == null)
            return false;

        unit.Name = dto.Name;
        unit.ShortName = dto.ShortName;

        await _repository.UpdateAsync(unit);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var unit = await _repository.GetByIdAsync(id);

        if (unit == null)
            return false;

        await _repository.DeleteAsync(unit);

        return true;
    }
}