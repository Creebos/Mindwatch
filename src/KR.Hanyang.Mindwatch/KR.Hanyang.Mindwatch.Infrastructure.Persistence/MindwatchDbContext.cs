using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence
{
    public class MindwatchDbContext : DbContext
    {
        public MindwatchDbContext(DbContextOptions<MindwatchDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } // DbSet for the entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Fluent API configurations here
        }
    }
}
