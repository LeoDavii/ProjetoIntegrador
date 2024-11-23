using Microsoft.EntityFrameworkCore;
using Source.Entities;
using Source.Mappings;
using Source.Options;

namespace Source.Context
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options, DatabaseContextOptions connectionOptions) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && connectionOptions?.ConnectionString is not null)
            {
                optionsBuilder.UseNpgsql(connectionOptions?.ConnectionString);
            }
        }
    }
}
