using ChatAPI.DTOs;
using ChatAPI.Data;
using ChatAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ChatAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _db.Users.ToListAsync();
        return Ok(users);
        
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _db.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {

        var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Username == request.Username || u.Email == request.Email);

        if (existingUser != null)
        {
            var usernameExists = existingUser.Username == request.Username;
            var emailExists = existingUser.Email == request.Email;

            if (emailExists && usernameExists)
                return BadRequest("Username and Email already in use.");
            if (usernameExists)
                return BadRequest("Username already in use.");
            if (emailExists)
                return BadRequest("Both the username and email are already in use.");        }
        
        var user = new User
        {
            Username = request.Username,
            Email = request.Email
        };

        _db.Users.Add(user);
       await _db.SaveChangesAsync();

       return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }
    
}