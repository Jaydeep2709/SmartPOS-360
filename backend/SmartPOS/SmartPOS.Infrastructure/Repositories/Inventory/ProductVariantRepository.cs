using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class ProductVariantRepository : IProductVariantRepository
{
    private readonly ApplicationDbContext _context;

    public ProductVariantRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductVariant>> GetAllAsync()
    {
        return await _context.ProductVariants
           // .Include(x => x.Product)
            .ToListAsync();
    }

    public async Task<ProductVariant?> GetByIdAsync(Guid id)
    {
        return await _context.ProductVariants
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(ProductVariant variant)
    {
        await _context.ProductVariants.AddAsync(variant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductVariant variant)
    {
        _context.ProductVariants.Update(variant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProductVariant variant)
    {
        _context.ProductVariants.Remove(variant);
        await _context.SaveChangesAsync();
    }
}