using SmartPOS.Domain.Inventory.Entities;

namespace SmartPOS.Application.Interfaces.IRepositories.Inventory;

public interface IUnitRepository
{
    Task<IEnumerable<Unit>> GetAllAsync();

    Task<Unit?> GetByIdAsync(Guid id);

    Task AddAsync(Unit unit);

    Task UpdateAsync(Unit unit);

    Task DeleteAsync(Unit unit);
}