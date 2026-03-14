using System.ComponentModel.DataAnnotations;

namespace ChatAPI.DTOs;

public class CreateUserRequest
{
    [Required]
    [MaxLength(24)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}