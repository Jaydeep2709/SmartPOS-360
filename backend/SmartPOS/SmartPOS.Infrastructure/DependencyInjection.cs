using Microsoft.Extensions.DependencyInjection;
using SmartPOS.Application.Interfaces.Irepositories.Inventory;
using SmartPOS.Infrastructure.Repositories.Inventory;

namespace SmartPOS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}