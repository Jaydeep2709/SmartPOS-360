using Microsoft.Extensions.DependencyInjection;
//using SmartPOS.Application.Interfaces.Inventory;
using SmartPOS.Application.Interfaces.Iservices.Inventory;
using SmartPOS.Application.Services.Inventory;

namespace SmartPOS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}