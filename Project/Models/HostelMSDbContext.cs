using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
        public class HostelMSDbContext : DbContext
        {
            public HostelMSDbContext(DbContextOptions<HostelMSDbContext> options) : base(options)
            {

            }

            public DbSet<Student> Students { get; set; }
          

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => p.ClrType == typeof(string)))
                {
                    property.SetColumnType("text");  // or "varchar"
                }

                // Other model configurations...
            }
        }
 }
