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
        }
}