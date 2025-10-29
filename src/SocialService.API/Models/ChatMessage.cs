namespace SocialService.API.Models;

public class ChatMessage
{
    public int ChatMessageID { get; set; }
    public int? UserID { get; set; }
    public string? Message { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}
