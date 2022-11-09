using Core.Dto;

namespace Core.Services.Interfaces;

public interface IUserHandler
{
    public Task<UserDto> CreateAsync(NewUserDto newUser, CancellationToken cancellationToken);
    
    public Task<UserDto> LoginAsync(LoginUserDto login, CancellationToken cancellationToken);
}