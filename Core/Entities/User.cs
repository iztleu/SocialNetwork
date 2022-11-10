using System.ComponentModel.DataAnnotations.Schema;
using Core.Dto;

namespace Core.Entities;

public class User
{
    public User(){}
    
    public User(NewUserDto newUser)
    {
        Username = newUser.Username;
        Password = newUser.Password;
        Email = newUser.Email;
    }
    
    [Column("user_name")]
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public uint? Age { get; set; }
    public string? Floor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
}