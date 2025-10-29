using Microsoft.EntityFrameworkCore;
using CartService.API.Models;

namespace CartService.API.Data;

public class CartDbContext(DbContextOptions<CartDbContext> opt) : DbContext(opt)
{
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Cart>(e =>
        {
            e.ToTable("Carts");
            e.HasKey(x => x.CartID);
            e.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            e.Property(x => x.Status).HasMaxLength(10).IsRequired();
        });

        b.Entity<CartItem>(e =>
        {
            e.ToTable("CartItems");
            e.HasKey(x => x.CartItemID);
            e.Property(x => x.Quantity).IsRequired();
            e.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();

            e.HasOne(x => x.Cart)
             .WithMany(c => c.Items)
             .HasForeignKey(x => x.CartID)
             .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
