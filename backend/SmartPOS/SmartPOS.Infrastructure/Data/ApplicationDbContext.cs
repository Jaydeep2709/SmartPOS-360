using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartPOS.Domain.Identity.Entities;
using SmartPOS.Domain.Inventory.Entities;
using SmartPOS.Domain.POS.Entities;
using SmartPOS.Domain.Reports.Entities;
using SmartPOS.Domain.Settings.Entities;
using SmartPOS.Domain.Store.Entities;
namespace SmartPOS.Infrastructure.Data;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, Role, Guid>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
    ) : base(options)
    {
    }

    // Store
    public DbSet<Store> Stores { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<Warehouse> Warehouses { get; set; }

    // Inventory
    public DbSet<Category> Categories { get; set; }

    public DbSet<Brand> Brands { get; set; }

    public DbSet<Unit> Units { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductVariant> ProductVariants { get; set; }

    public DbSet<Stock> Stocks { get; set; }

    public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    // POS
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Sale> Sales { get; set; }

    public DbSet<SaleItem> SaleItems { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Discount> Discounts { get; set; }

    public DbSet<Tax> Taxes { get; set; }

    // Reports
    public DbSet<SalesReport> SalesReports { get; set; }

    // Settings
    public DbSet<ApplicationSetting> ApplicationSettings { get; set; }

    public DbSet<LanguageSetting> LanguageSettings { get; set; }

    public DbSet<ThemeSetting> ThemeSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasIndex(x => x.SKU)
            .IsUnique();

        builder.Entity<Product>()
            .HasIndex(x => x.Barcode)
            .IsUnique();

        builder.Entity<Sale>()
            .HasIndex(x => x.InvoiceNumber)
            .IsUnique();

        builder.Entity<PurchaseOrderItem>()
            .HasOne(x => x.PurchaseOrder)
            .WithMany(x => x.PurchaseOrderItems)
            .HasForeignKey(x => x.PurchaseOrderId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}