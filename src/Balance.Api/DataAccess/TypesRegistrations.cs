using Balance.Api.DataAccess.Internals;
using Microsoft.EntityFrameworkCore;

namespace Balance.Api.DataAccess;

public static class TypesRegistrations
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<AppDbContext>(e => e.UseNpgsql(configuration.GetConnectionString("default")))
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}