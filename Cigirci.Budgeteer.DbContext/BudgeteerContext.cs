namespace Cigirci.Budgeteer.DbContext;

using Cigirci.Budgeteer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
}