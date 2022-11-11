using Core.Dto;
using LanguageExt.Common;

namespace Core.Services.Interfaces;

public interface IUserHandler
{
    public Task<Result<UserDto>> CreateAsync(NewUserDto newUser, CancellationToken cancellationToken);
    
    public Task<Result<UserDto>> LoginAsync(LoginUserDto login, CancellationToken cancellationToken);
    
    public Task<Result<UserDto>> UpdateAsync(string email, UpdateUserDto updateUserDto, CancellationToken cancellationToken);
}