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
    
    private void Configure<T>(ModelBuilder modelBuilder) where T: Record
    {
        var user = _httpContextAccessor?.HttpContext?.User.GetUserId();

        modelBuilder.Entity<T>()
            .HasQueryFilter(record => record.Owner.Id == user);
    }


    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var user = _httpContextAccessor?.HttpContext?.User.GetUserId();

        foreach (var entry in ChangeTracker.Entries())
        {
            //verify entry (row) is a record
            //verify if entry belongs to the user
            if (entry.Entity is not Record record) continue;
            if (record.Owner.Id is not null && record.Owner.Id != user) continue;

            //verify if record owner belongs to current user
            if (user is null) continue;
            if (record.Owner.Id != user) continue;

            if (entry.State == EntityState.Modified)
            {
                //verify if record is contains 'modified' metadata information & if modifying user is set appropriately
                if (record.Modified is null) continue;
                if (record.Modified.By != user) continue;
            }

            if (entry.State == EntityState.Added)
            {
                //verify if record is contains 'created' metadata information & if creating user is set appropriately
                if (record.Created is null) continue;
                if (record.Created.By != user) continue;
            }


            if (record?.Created?.By != user) continue;

            if (entry.State != EntityState.Added && entry.State != EntityState.Modified) continue;
            if (user is null) continue;



            if (entry.State != EntityState.Added) continue;

            //record.Modified = MetadataHelper.BuildModified(Guid.NewGuid());            
            //record.Status = MetadataHelper.BuildStatus();
            //record.Owner = MetadataHelper.BuildOwner(user.Value);
            //record.Created = MetadataHelper.BuildCreated(user.Value);
        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}