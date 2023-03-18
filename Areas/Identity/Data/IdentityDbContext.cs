using CAMPUSproject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CAMPUSproject.Data;

public class IdentityDbContext : IdentityDbContext<MyProjectUser>
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserEntityConfiguration());
        builder.Entity<MyProjectUser>()
        .HasOne(u => u.Project)
        .WithMany(p => p.Users)
        .HasForeignKey(u => u.ProjectId);

    }

    public class UserEntityConfiguration : IEntityTypeConfiguration<MyProjectUser>
    {
        public void Configure(EntityTypeBuilder<MyProjectUser> builder)
        {

        }
    }
}
