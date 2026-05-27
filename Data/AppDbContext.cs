using MeuVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuVeiculo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<FuelLog> FuelLogs { get; set; }
    public DbSet<MaintenaceLog> MaintenanceLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(u => u.Username).IsUnique();
            e.Property(u => u.Username).HasMaxLength(50).IsRequired();
            e.Property(u => u.PasswordHash).IsRequired();
        });

        modelBuilder.Entity<Vehicle>(e =>
        {
            e.Property(v => v.Type).HasConversion<string>();
            e.Property(v => v.Fuel).HasConversion<string>();
            e.HasOne(v => v.User)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FuelLog>(e =>
        {
            e.Property(f => f.Liters).HasColumnType("decimal(8,2)");
            e.Property(f => f.TotalCost).HasColumnType("decimal(10,2)");
            e.Property(f => f.PricePerLiter).HasColumnType("decimal(8,3)");
            e.HasOne(f => f.Vehicle)
                .WithMany(v => v.FuelLogs)
                .HasForeignKey(f => f.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MaintenaceLog>(e =>
        {
            e.Property(m => m.Category).HasConversion<string>();
            e.Property(m => m.Price).HasColumnType("decimal(10,2)");
            e.HasOne(m => m.Vehicle)
                .WithMany(v => v.MaintenanceLogs)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
