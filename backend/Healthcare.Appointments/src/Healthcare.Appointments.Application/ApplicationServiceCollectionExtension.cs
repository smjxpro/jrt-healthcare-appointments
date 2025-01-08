using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Healthcare.Appointments.Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddMapster();

        return services;
    }
}