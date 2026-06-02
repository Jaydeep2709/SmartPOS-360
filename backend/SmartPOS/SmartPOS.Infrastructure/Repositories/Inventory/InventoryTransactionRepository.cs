using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Infrastructure.Data;

namespace SmartPOS.Infrastructure.Repositories.Inventory;

public class InventoryTransactionRepository
    : IInventoryTransactionRepository
{
    private readonly ApplicationDbContext _context;

    public InventoryTransactionRepository(
        ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InventoryTransaction>> GetAllAsync()
    {
        return await _context.InventoryTransactions
            .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<InventoryTransaction?> GetByIdAsync(Guid id)
    {
        return await _context.InventoryTransactions
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(
        InventoryTransaction transaction)
    {
        await _context.InventoryTransactions.AddAsync(transaction);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(
        InventoryTransaction transaction)
    {
        _context.InventoryTransactions.Update(transaction);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(
        InventoryTransaction transaction)
    {
        _context.InventoryTransactions.Remove(transaction);

        await _context.SaveChangesAsync();
    }
}