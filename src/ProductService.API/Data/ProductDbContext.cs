using Microsoft.EntityFrameworkCore;
using ProductService.API.Models;

namespace ProductService.API.Data;

public class ProductDbContext(DbContextOptions<ProductDbContext> opt) : DbContext(opt)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Category>(e =>
        {
            e.ToTable("Categories");
            e.HasKey(x => x.CategoryID);
            e.Property(x => x.CategoryName).HasMaxLength(100).IsRequired();
        });

        b.Entity<Product>(e =>
        {
            e.ToTable("Products");
            e.HasKey(x => x.ProductID);
            e.Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            e.Property(x => x.BriefDescription).HasMaxLength(255);
            e.Property(x => x.FullDescription);
            e.Property(x => x.TechnicalSpecifications);
            e.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            e.Property(x => x.ImageURL).HasMaxLength(255);

            e.HasOne(p => p.Category)
             .WithMany(c => c.Products)
             .HasForeignKey(p => p.CategoryID)
             .OnDelete(DeleteBehavior.SetNull);
        });
    }
}
