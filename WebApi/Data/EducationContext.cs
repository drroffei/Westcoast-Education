using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class EducationContext : DbContext
    {
        public EducationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<CourseCustomerCurrent> CourseCustomerCurrent => Set<CourseCustomerCurrent>();
        public DbSet<CourseCustomerFinished> CourseCustomerFinished => Set<CourseCustomerFinished>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            modelBuilder.Entity<CourseCustomerCurrent>().HasKey(cc => new{cc.CourseId, cc.CustomerId} );
            modelBuilder.Entity<CourseCustomerFinished>().HasKey(cc => new{cc.CourseId, cc.CustomerId} );
        }
    }
}