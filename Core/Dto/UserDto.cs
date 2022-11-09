using System.ComponentModel.DataAnnotations;

namespace Core.Dto;

public record NewUserDto(string Username, string Email, string Password);

public record LoginUserDto(string Email, string Password);

public record UserDto( string Username, string Email, string Token);
    
    
