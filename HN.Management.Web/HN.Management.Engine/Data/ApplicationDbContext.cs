using HN.Management.Engine.Models;
using HN.ManagementEngine.Models;
using Microsoft.EntityFrameworkCore;

namespace HN.Management.Engine.Data
{
     public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<Project> Proyect { get; set; }

        public DbSet<Donor> Donor { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Donation> Donation { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<Evidence> Evidence { get; set; }

        public DbSet<UserPermit> UserPermit { get; set; }
    }
}
