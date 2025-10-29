using Microsoft.EntityFrameworkCore;
using PaymentService.API.Models;

namespace PaymentService.API.Data;

public class PaymentDbContext(DbContextOptions<PaymentDbContext> opt) : DbContext(opt)
{
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Payment>(e =>
        {
            e.ToTable("Payments");
            e.HasKey(x => x.PaymentID);
            e.Property(x => x.Amount).HasColumnType("decimal(18,2)").IsRequired();
            e.Property(x => x.PaymentStatus).HasMaxLength(50).IsRequired();
            e.Property(x => x.PaymentDate).HasDefaultValueSql("GETDATE()");
        });
    }
}
