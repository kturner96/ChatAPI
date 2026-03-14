namespace ChatAPI.Domain;

public class ConversationParticipant
{
    public int ConversationId { get; set; }
    public int UserId { get; set; }
    public int JoinedAt { get; set; }
}