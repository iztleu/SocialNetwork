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

    public UserDto GetDto(string token)
    {
        return new UserDto(Email, Name, Surname, Age, Floor, Interests, City, Image, token);
    }
    
    public long Id { get; set; } 
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string? Surname { get; set; }
    public uint? Age { get; set; }
    public string? Floor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Image { get; set; }

    public void Update(UpdateUserDto updateUserDto)
    {
        Name = updateUserDto.Name;
        Surname = updateUserDto.Surname ?? Surname;
        Age = updateUserDto.Age ?? Age;
        Floor = updateUserDto.Floor ?? Floor;
        Interests = updateUserDto.Interests ?? Interests;
        City = updateUserDto.City ?? City;
        Image = updateUserDto.Image ?? Image;
    }
}