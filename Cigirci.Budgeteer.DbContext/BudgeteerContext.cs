namespace Cigirci.Budgeteer.DbContext;

using Cigirci.Budgeteer.Interfaces.Metadata.Record.Types;
using Cigirci.Budgeteer.Models;
using Cigirci.Budgeteer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

public class BudgeteerContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public BudgeteerContext(DbContextOptions<BudgeteerContext> options, IConfiguration? configuration = null) : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Transaction>? Transactions { get; set; }

    public virtual DbSet<Profile>? Profiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("BudgeteerDb");

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Created created)
            {
                if (entry.State == EntityState.Added)
                {
                    created.On = DateTime.Now;
                }
            }

            if (entry.Entity is Modified modified)
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    modified.On = DateTime.Now;
                }
            }

            var record = entry.Entity is Record;
            var state = entry.State;
            var values = entry.CurrentValues;
            var entity = entry.Entity;
        }
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}