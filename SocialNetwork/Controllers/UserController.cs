using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication;
using Core.Dto;
using Core.Services.Interfaces;
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
    public async Task<IActionResult> Register(NewUserDto newUser, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _userHandler.CreateAsync(newUser, cancellationToken);
            return result.Match();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Problem(detail: ex.Message);
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto newUser, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _userHandler.LoginAsync(newUser, cancellationToken);
            return result.Match();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Problem(detail: ex.Message);
        }
    }
}