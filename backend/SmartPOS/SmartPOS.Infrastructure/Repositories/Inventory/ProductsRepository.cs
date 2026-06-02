using Microsoft.EntityFrameworkCore;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Infrastructure.Data;

namespace SmartPOS.Infrastructure.Repositories.Inventory;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.Unit)
            .Include(x => x.Supplier)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.Unit)
            .Include(x => x.Supplier)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product?> GetBySkuAsync(string sku)
    {
        return await _context.Products
            .FirstOrDefaultAsync(x => x.SKU == sku);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}