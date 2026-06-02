using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Infrastructure.Data;

namespace SmartPOS.Infrastructure.Repositories.Inventory;

public class UnitRepository : IUnitRepository
{
    private readonly ApplicationDbContext _context;

    public UnitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Unit>> GetAllAsync()
    {
        return await _context.Units.ToListAsync();
    }

    public async Task<Unit?> GetByIdAsync(Guid id)
    {
        return await _context.Units.FindAsync(id);
    }

    public async Task AddAsync(Unit unit)
    {
        await _context.Units.AddAsync(unit);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Unit unit)
    {
        _context.Units.Update(unit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Unit unit)
    {
        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();
    }
}