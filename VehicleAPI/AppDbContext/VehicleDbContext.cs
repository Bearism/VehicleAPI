using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VehicleAPI.Models;

namespace VehicleAPI.AppDbContext;


public class VehicleDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Boat> Boats { get; set; }

    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<Bus>().HasData(
            new Bus {Id = 1, Color = "Red"},
            new Bus {Id = 2, Color = "Gray"},
            new Bus {Id = 3, Color = "White"});
    }
}
