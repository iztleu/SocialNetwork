using System.Security.Authentication;
using Core.Dto;
using Core.Entities;
using Core.Services.Interfaces;
using SocialNetwork.Utils.Interfaces;

namespace Core.Services;

public class UserHandler: IUserHandler
{
    private readonly IUserRepository _repository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserHandler(ITokenGenerator tokenGenerator, IUserRepository repository)
    {
        _tokenGenerator = tokenGenerator;
        _repository = repository;
    }

    public async Task<UserDto> CreateAsync(NewUserDto newUser, CancellationToken cancellationToken)
    {
        var user = new User(newUser);
        await _repository.AddUserAsync(user);
        var token = _tokenGenerator.CreateToken(user.Username);
        return new UserDto(user.Username, user.Email, token);
    }

    public async Task<UserDto> LoginAsync(LoginUserDto login, CancellationToken cancellationToken)
    { 
        var user = await _repository.GetUserByEmailAsync(login.Email);
        
        if (user == null || user.Password != login.Password)
        {
            throw new AuthenticationException("incorrect credentials");
        }

        var token = _tokenGenerator.CreateToken(user.Username);
        return new UserDto(user.Username, user.Email, token);
    }
}