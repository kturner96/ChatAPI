namespace ChatAPI.Domain;

public class Conversation
{
    public int ConversationId { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}