using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Application.Interfaces.Irepositories.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartPOS.Infrastructure.Repositories.Inventory
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Stocks
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(Guid id)
        {
            return await _context.Stocks
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stock?> GetByProductAndWarehouseAsync(
            Guid productId,
            Guid warehouseId)
        {
            return await _context.Stocks
                .FirstOrDefaultAsync(x =>
                    x.ProductId == productId &&
                    x.WarehouseId == warehouseId);
        }

        public async Task AddAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stock stock)
        {
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Stock stock)
        {
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
        }
    }
}
