using Microsoft.EntityFrameworkCore;
using VintageCarGarageAPI.Models;

namespace VintageCarGarageAPI.Data
{
    public class InsideBoxContext : DbContext
    {
        public InsideBoxContext(DbContextOptions<InsideBoxContext> options) : base(options) { }

        // Define the Users table
        public DbSet<User> Users { get; set; } = null!;

        // Define the Cars table
        public DbSet<Car> Cars { get; set; } = null!;

        // Define the Services table
        public DbSet<Service> Services { get; set; } = null!;

        // Configure the model (e.g., set constraints, relationships, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the User entity
            modelBuilder.Entity<User>(entity =>
            {
                // Set the primary key
                entity.HasKey(u => u.Id);

                // Set unique constraint on the Email column
                entity.HasIndex(u => u.Email).IsUnique();

                // Configure properties
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Phone).HasMaxLength(20); // Add phone field
                entity.Property(u => u.Role).IsRequired().HasMaxLength(50);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // Configure the Car entity
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).IsRequired();
                entity.Property(c => c.ImageUrl).IsRequired();
            });

            // Configure the Service entity
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Description).IsRequired();
            });
        }
    }
}