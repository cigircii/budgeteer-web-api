namespace Cigirci.Budgeteer.DbContext;

using Cigirci.Budgeteer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    private readonly IConfiguration _config;

    public ApplicationDbContext(IConfiguration config, DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
            .ToTable("user");

        builder.Entity<ApplicationRole>()
            .ToTable("role");

        builder.Entity<IdentityUserRole<Guid>>()
            .ToTable("userrole");

        builder.Entity<IdentityUserClaim<Guid>>()
            .ToTable("userclaim");

        builder.Entity<IdentityUserLogin<Guid>>()
            .ToTable("userlogin");

        builder.Entity<IdentityRoleClaim<Guid>>()
            .ToTable("roleclaim");

        builder.Entity<IdentityUserToken<Guid>>()
            .ToTable("usertoken");
    }
}
