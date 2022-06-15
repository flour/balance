using Balance.Api.Commons.Domain;
using Balance.Api.Commons.Enums;
using Balance.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Balance.Api.Extensions;

public static class StartupExtensions
{
    public static async Task Migrate(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        await context.SeedOwners();
        await context.SeedAccountCharts();
        await context.SeedAccounts();
    }

    private static async Task<AppDbContext> SeedOwners(this AppDbContext context)
    {
        if (await context.Owners.AnyAsync())
            return context;

        var owners = Enumerable.Range(1, 10).Select(e => new Owner
        {
            Name = e == 1 ? "System" : $"Client {e:0000}",
            Type = e == 1 ? OwnerType.Partner : OwnerType.Client,
        });

        await context.AddRangeAsync(owners);
        await context.SaveChangesAsync();
        return context;
    }

    private static async Task<AppDbContext> SeedAccountCharts(this AppDbContext context)
    {
        if (await context.AccountCharts.AnyAsync())
            return context;
        var charts = new[]
        {
            new {code = "42309", negative = false, active = false},
            new {code = "40817", negative = false, active = false},
            new {code = "20299", negative = false, active = true},

            new {code = "20202", negative = true, active = true},
            new {code = "70601", negative = true, active = false},
            new {code = "70606", negative = true, active = true},
            new {code = "30114", negative = true, active = true},
            new {code = "30106", negative = true, active = true},
        }.Select(e => new AccountChart {Active = e.active, NegativeAllowed = e.negative, Number = e.code});

        await context.AddRangeAsync(charts);
        await context.SaveChangesAsync();

        return context;
    }

    private static async Task<AppDbContext> SeedAccounts(this AppDbContext context)
    {
        if (await context.Accounts.AnyAsync())
            return context;
        return context;
    }
}