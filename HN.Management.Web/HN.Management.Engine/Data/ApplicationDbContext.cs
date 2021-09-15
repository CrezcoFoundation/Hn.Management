using HN.Management.Engine.Models;
using HN.ManagementEngine.Models;
using Microsoft.EntityFrameworkCore;

namespace HN.Management.Engine.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Proyect { get; set; }

        public DbSet<Donor> Donor { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Donation> Donation { get; set; }

        public DbSet<Expense> Expense { get; set; }

        public DbSet<Evidence> Evidence { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, RoleName = "Admin" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = "Student" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, RoleName = "Donor" });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "anaeltrabajo@gmail.com", PasswordHash = "Admin", IsEmailConfirmed = true, RoleId = 1, RoleName = "Admin" });
        }
    }
}
