using Microsoft.Extensions.DependencyInjection;
//using SmartPOS.Application.Interfaces.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Inventory;
using SmartPOS.Application.Services.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Identity;
using SmartPOS.Application.Services.Identity;
using SmartPOS.Infrastructure.Services.Identity;
using SmartPOS.Application.Interfaces.IServices.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Store;
using SmartPOS.Application.Services.Store;

namespace SmartPOS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        //Identity
        #region
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRoleService, RoleService>();
        #endregion

        //Inventory
        #region
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductVariantService, ProductVariantService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IInventoryTransactionService, InventoryTransactionService>();
        services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
        #endregion

        //Store
        #region
        services.AddScoped<IWarehouseService, WarehouseService>();
        #endregion

        return services;
    }
}