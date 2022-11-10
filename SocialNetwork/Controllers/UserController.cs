using Core.Dto;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers;
 
[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserHandler _userHandler;
    
    public UserController(IUserHandler userHandler)
    {
        _userHandler = userHandler;
    }
   
    [HttpPost("register")]
    public async Task<ActionResult<UserEnvelope<UserDto>>> Register(
            RequestEnvelope<UserEnvelope<NewUserDto>> request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userHandler.CreateAsync(request.Body.User, cancellationToken);
            return Ok(new UserEnvelope<UserDto>(user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem(detail: e.Message);
        }
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<UserEnvelope<UserDto>>> Login(
        RequestEnvelope<UserEnvelope<LoginUserDto>> request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userHandler.LoginAsync(request.Body.User, cancellationToken);
            return Ok(new UserEnvelope<UserDto>(user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Problem(detail: e.Message);
        }
    }
}