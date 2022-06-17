using Balance.Api.DataAccess;
using Balances.Commons.Mediatr;
using Flour.ServiceBus.MassTransit.RabbitMq.DependencyInjection;

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
            .AddPreconfiguredMediatr(typeof(TypesRegistrations));
    }
}