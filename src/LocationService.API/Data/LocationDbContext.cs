using Microsoft.EntityFrameworkCore;
using LocationService.API.Models;

namespace LocationService.API.Data;

public class LocationDbContext(DbContextOptions<LocationDbContext> opt) : DbContext(opt)
{
    public DbSet<StoreLocation> StoreLocations => Set<StoreLocation>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<StoreLocation>(e =>
        {
            e.ToTable("StoreLocations");
            e.HasKey(x => x.LocationID);
            e.Property(x => x.Address).HasMaxLength(255).IsRequired();
            e.Property(x => x.Latitude).HasColumnType("decimal(9,6)").IsRequired();
            e.Property(x => x.Longitude).HasColumnType("decimal(9,6)").IsRequired();
        });
    }
}
