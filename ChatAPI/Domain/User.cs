using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MessagingAPI.Api.Domain;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
}