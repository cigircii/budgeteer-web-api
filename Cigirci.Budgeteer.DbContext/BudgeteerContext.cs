namespace Cigirci.Budgeteer.DbContext;

using Cigirci.Budgeteer.DbContext.Helper;
using Cigirci.Budgeteer.Models;
using Cigirci.Budgeteer.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

public class BudgeteerContext : DbContext
{
    private readonly IConfiguration? _configuration;
    private readonly IHttpContextAccessor? _httpContextAccessor;

    public BudgeteerContext(DbContextOptions<BudgeteerContext> options, IConfiguration? configuration = null, IHttpContextAccessor? httpContextAccessor = null) : base(options)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual DbSet<Company>? Companies { get; set; }
    public virtual DbSet<Goal>? Goals { get; set; }
    public virtual DbSet<Group>? Groups { get; set; }
    public virtual DbSet<Member>? Members { get; set; }
    public virtual DbSet<Profile>? Profiles { get; set; }
    public virtual DbSet<Settings>? Settings { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
    public virtual DbSet<Transaction>? Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("BudgeteerDb");

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        var id = user?.FindFirstValue(ClaimTypes.NameIdentifier);

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not Record record) continue;

            record.Modified = MetadataHelper.BuildModified(Guid.NewGuid());

            if (entry.State != EntityState.Added) continue;

            record.Created = MetadataHelper.BuildCreated(Guid.NewGuid());
            record.Status = MetadataHelper.BuildStatus();
            record.Owner = MetadataHelper.BuildOwner();
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}