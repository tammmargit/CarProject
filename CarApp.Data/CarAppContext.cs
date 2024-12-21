using Microsoft.EntityFrameworkCore.Design;

using CarApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Data;

public class CarAppContext : DbContext
{
    public CarAppContext(DbContextOptions<CarAppContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration for Car entity
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Make).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Model).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.ModifiedAt).IsRequired();
        });
    }
    public class CarAppContextFactory : IDesignTimeDbContextFactory<CarAppContext>
    {
        public CarAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarAppContext>();
            optionsBuilder.UseSqlServer("Server=MSI\\MSSQLSERVER01;Database=CarAppDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new CarAppContext(optionsBuilder.Options);
        }
    }
}
