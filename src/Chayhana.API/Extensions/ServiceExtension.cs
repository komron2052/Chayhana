using Chayhana.Data.IRepositories;
using Chayhana.Data.Repositories;
using Chayhana.Service.Interfaces;
using Chayhana.Service.Services;

namespace Chayhana.API.Extensions;

public static class ServiceExtension
{

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMealService, MealService>();
        services.AddScoped<IOrderService, OrderService>();
    }
}
