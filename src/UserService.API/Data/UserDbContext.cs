using Microsoft.EntityFrameworkCore;
using UserService.API.Models;

namespace UserService.API.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<User>(e =>
        {
            e.ToTable("Users");
            e.HasKey(x => x.UserID);
            e.Property(x => x.Username).HasMaxLength(50).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
            e.Property(x => x.Email).HasMaxLength(100).IsRequired();
            e.Property(x => x.PhoneNumber).HasMaxLength(15);
            e.Property(x => x.Address).HasMaxLength(255);
            e.Property(x => x.Role).HasMaxLength(50).IsRequired();
        });
    }
}
