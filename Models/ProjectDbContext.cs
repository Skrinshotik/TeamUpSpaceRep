using CAMPUSproject.Areas.Identity.Data;
using CAMPUSproject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUpSpace.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ProjectModel> GetProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjectModel>()
                 .HasMany(u => u.Users);
        }


    }
}
