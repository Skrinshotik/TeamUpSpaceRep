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
        public DbSet<ProjectModel> Projects { get; set; }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }
        
    }
}
