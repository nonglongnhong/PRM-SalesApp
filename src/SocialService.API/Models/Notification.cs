namespace SocialService.API.Models;

public class Notification
{
    public int NotificationID { get; set; }
    public int? UserID { get; set; } // cross-service id
    public string? Message { get; set; }
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
