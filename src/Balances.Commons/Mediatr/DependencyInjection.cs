using Balances.Commons.Mediatr.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Balances.Commons.Mediatr;

public static class DependencyInjection
{
    public static IServiceCollection AddPreconfiguredMediatr(
        this IServiceCollection services,
        Type lookupType,
        bool withValidator = true)
    {
        services.AddMediatR(lookupType ?? throw new ArgumentNullException(nameof(lookupType)));

        if (withValidator)
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

        return services;
    }
}