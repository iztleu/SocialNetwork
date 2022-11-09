using Core.Dto;
using Core.Services.Interfaces;
using SocialNetwork.Utils.Interfaces;

namespace Core.Services;

public class UserHandler: IUserHandler
{
    private readonly ITokenGenerator _tokenGenerator;

    public UserHandler(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public Task<UserDto> CreateAsync(NewUserDto newUser, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> LoginAsync(LoginUserDto login, CancellationToken cancellationToken)
    { 
        throw new NotImplementedException();
    }
}