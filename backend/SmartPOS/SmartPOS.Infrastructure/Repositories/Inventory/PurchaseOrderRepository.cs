using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Infrastructure.Data;

namespace SmartPOS.Infrastructure.Repositories.Inventory;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly ApplicationDbContext _context;

    public PurchaseOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PurchaseOrder>> GetAllAsync()
    {
        return await _context.PurchaseOrders
            .Include(x => x.PurchaseOrderItems)
            .ToListAsync();
    }

    public async Task<PurchaseOrder?> GetByIdAsync(Guid id)
    {
        return await _context.PurchaseOrders
            .Include(x => x.PurchaseOrderItems)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(PurchaseOrder order)
    {
        await _context.PurchaseOrders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PurchaseOrder order)
    {
        _context.PurchaseOrders.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PurchaseOrder order)
    {
        _context.PurchaseOrders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task ReceiveAsync(PurchaseOrder order)
    {
        foreach (var item in order.PurchaseOrderItems)
        {
            var stock = await _context.Stocks
                .FirstOrDefaultAsync(x =>
                    x.ProductId == item.ProductId);

            if (stock != null)
            {
                stock.Quantity += item.Quantity;
            }
            else
            {
                await _context.Stocks.AddAsync(
                    new Stock
                    {
                        Id = Guid.NewGuid(),
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        ReservedQuantity = 0,
                        WarehouseId = Guid.Empty
                    });
            }
        }

        order.Status = "Received";
        order.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}