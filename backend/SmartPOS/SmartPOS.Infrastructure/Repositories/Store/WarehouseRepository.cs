using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces.Irepositories.Store;
using SmartPOS.Domain.Store.Entities;
using SmartPOS.Infrastructure.Data;

namespace SmartPOS.Infrastructure.Repositories.Store
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _context;

        public WarehouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse?> GetByIdAsync(Guid id)
        {
            return await _context.Warehouses
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Warehouse warehouse)
        {
            await _context.Warehouses.AddAsync(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Warehouse warehouse)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
