using Balance.Api.DataAccess;
using CS.Sdk.ServiceBus.MassTransit.RabbitMq.DependencyInjection;
using MediatR;

namespace Balance.Api.Extensions;

public static class TypesRegistrations
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                // infra
                .AddMassTransitRabbitMq(configuration, consumersAssemblies: typeof(TypesRegistrations).Assembly)
                .AddDataAccess(configuration)
                
                // service and business
                .AddMediatR(typeof(TypesRegistrations))
                
            ;
    }
}