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
    public virtual DbSet<Subscription>? Subscriptions { get; set; }
    public virtual DbSet<Transaction>? Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("BudgeteerDb");

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var user = _httpContextAccessor?.HttpContext?.User.GetUserId();
        
        modelBuilder.Entity<Company>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Goal>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Group>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Member>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Profile>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Settings>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Subscription>()
            .HasQueryFilter(record => record.Owner.Id == user);

        modelBuilder.Entity<Transaction>()
            .HasQueryFilter(record => record.Owner.Id == user);
    }


    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var user = _httpContextAccessor?.HttpContext?.User.GetUserId();
        if (user is null) return Task.FromResult(0);
        
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not Record record) continue;
            if (entry.State != EntityState.Added && entry.State != EntityState.Modified) continue;
            
            record.Modified = MetadataHelper.BuildModified(Guid.NewGuid());

            if (entry.State != EntityState.Added) continue;
            
            record.Status = MetadataHelper.BuildStatus();
            record.Owner = MetadataHelper.BuildOwner(user.Value);
            record.Created = MetadataHelper.BuildCreated(user.Value);
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}