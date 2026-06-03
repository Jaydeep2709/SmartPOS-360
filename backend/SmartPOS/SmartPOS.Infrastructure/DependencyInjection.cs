using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Interfaces.Irepositories.Inventory;
using SmartPOS.Application.Interfaces.Irepositories.Store;
using SmartPOS.Application.Interfaces.IRepositories.Identity;
using SmartPOS.Application.Interfaces.IRepositories.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Identity;
using SmartPOS.Application.Services.Identity;
using SmartPOS.Infrastructure.Repositories.Identity;
using SmartPOS.Infrastructure.Repositories.Inventory;
using SmartPOS.Infrastructure.Repositories.Store;
using SmartPOS.Infrastructure.Services.Identity;

namespace SmartPOS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        //Identity
        #region
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        #endregion

        //Inventory
        #region
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped< IInventoryTransactionRepository, InventoryTransactionRepository>();
        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
        #endregion

        //Store
        #region
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        #endregion
        return services;
    }
}