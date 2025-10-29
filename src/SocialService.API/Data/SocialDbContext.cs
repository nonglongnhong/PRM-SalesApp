using Microsoft.EntityFrameworkCore;
using SocialService.API.Models;

namespace SocialService.API.Data;

public class SocialDbContext(DbContextOptions<SocialDbContext> opt) : DbContext(opt)
{
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Notification>(e =>
        {
            e.ToTable("Notifications");
            e.HasKey(x => x.NotificationID);
            e.Property(x => x.Message).HasMaxLength(255);
            e.Property(x => x.IsRead).HasDefaultValue(false);
            e.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
        });

        b.Entity<ChatMessage>(e =>
        {
            e.ToTable("ChatMessages");
            e.HasKey(x => x.ChatMessageID);
            e.Property(x => x.SentAt).HasDefaultValueSql("GETDATE()");
        });
    }
}
