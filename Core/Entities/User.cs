using System.ComponentModel.DataAnnotations.Schema;
using Core.Dto;

namespace Core.Entities;

public class User
{
    public User(){}
    
    public User(NewUserDto newUser)
    {
        Name = newUser.Name;
        Password = newUser.Password;
        Email = newUser.Email;
        Surname = newUser.Surname;
        Age = newUser.Age;
        Floor = newUser.Floor;
        Interests = newUser.Interests;
        City = newUser.City;
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string? Surname { get; set; }
    public uint? Age { get; set; }
    public string? Floor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Image { get; set; }
}