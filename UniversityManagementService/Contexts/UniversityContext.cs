using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManagementService.Models;

namespace UniversityManagementService.Contexts
{
    public class UniversityContext: DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options) { }
        public UniversityContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UniversityRole>()
                .HasKey(ur => new { ur.UniversityId, ur.RoleId });

            modelBuilder.Entity<RoleUser>()
                .HasKey(ur => new { ur.RoleId, ur.UserId });
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UniversityRole> UniversityRoles { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
    }
}
