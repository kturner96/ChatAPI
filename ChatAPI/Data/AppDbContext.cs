using ChatAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Conversation> Conversations => Set<Conversation>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<ConversationParticipant> ConversationParticipants => Set<ConversationParticipant>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConversationParticipant>()
            .HasKey(cp => new { cp.ConversationId, cp.UserId });
    }
}