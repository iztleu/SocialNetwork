using Core.Dto;

namespace Core.Entities;

public class User
{
    public User(NewUserDto newUser)
    {
        Username = newUser.Username;
        Password = newUser.Password;
        Email = newUser.Email;
    }
    
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public uint Age { get; set; }
    public string? Floor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
}