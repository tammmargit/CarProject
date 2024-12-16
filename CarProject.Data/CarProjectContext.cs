using CarProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CarProject.Data;

namespace CarProject.Data;

public class CarProjectContext : DbContext
{
    public CarProjectContext(DbContextOptions<CarProjectContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
}

public class CarProjectContextFactory : IDesignTimeDbContextFactory<CarProjectContext>
{
    public CarProjectContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarProjectContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=CarProject;User Id=sa;Password=Valuetech@123;MultipleActiveResultSets=true;Encrypt=False; TrustServerCertificate=True");

        return new CarProjectContext(optionsBuilder.Options);
    }
}
