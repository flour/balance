using Balance.Api.Commons.Domain;
using Microsoft.EntityFrameworkCore;

namespace Balance.Api.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<AccountChart> AccountCharts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DocumentEntry> Entries { get; set; }
    public DbSet<OperationTemplate> Templates { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>()
            .HasOne(e => e.Owner).WithMany(e => e.Accounts);

        modelBuilder.Entity<Account>()
            .HasOne(e => e.AccountChart).WithMany(e => e.Accounts);
    }
}