namespace ChatAPI.Domain;

public class Message
{
    public int MessageId { get; set; }
    public int ConversationId { get; set; }
    public int SenderId { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    
}