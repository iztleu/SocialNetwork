using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using Core.Dto;
using Core.Entities;
using Core.Services.Interfaces;
using LanguageExt.Common;
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

    public async Task<Result<UserDto>> CreateAsync(NewUserDto newUser, CancellationToken cancellationToken)
    {
        if (await _repository.GetUserByEmailAsync(newUser.Email, cancellationToken) != null)
        {
            return new Result<UserDto>(new ValidationException("email already exists"));
        }

        var user = new User(newUser);
        await _repository.AddUserAsync(user, cancellationToken);
        return user.GetDto(_tokenGenerator.CreateToken(user.Email));
    }

    public async Task<Result<UserDto>> LoginAsync(LoginUserDto login, CancellationToken cancellationToken)
    { 
        var user = await _repository.GetUserByEmailAsync(login.Email, cancellationToken);
        
        if (user == null || user.Password != login.Password)
        {
            return new Result<UserDto>(new AuthenticationException("incorrect credentials"));
        }

        return user.GetDto(_tokenGenerator.CreateToken(user.Email));
    }

    public async Task<Result<UserDto>> UpdateAsync(string email, UpdateUserDto updateUserDto, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByEmailAsync(email, cancellationToken);
        
        if (user == null)
        {
            return new Result<UserDto>(new ArgumentNullException("Not found"));
        }

        user.Update(updateUserDto);
        
        await _repository.UpdateAsync(user, cancellationToken);
        
        return user.GetDto(_tokenGenerator.CreateToken(user.Email));
    }
}