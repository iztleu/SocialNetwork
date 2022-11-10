using System.ComponentModel.DataAnnotations;

namespace Core.Dto;

public record NewUserDto(string Email, string Password, string Name, 
    string? Surname , uint Age, string Floor, string? Interests, string? City);

public record LoginUserDto(string Email, string Password);

public record UserDto( string Name, string Email, string Token);
    
    
