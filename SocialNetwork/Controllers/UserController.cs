using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Models.ViewModels.Requests;

namespace SocialNetwork.Controllers;
  


[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    const string KEY = "mysupersecret_secretkey!123";
    [HttpPost]
    public IActionResult Register([FromBody]RegistrationRequest request)
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Ok();
    }
    
    [HttpPost]
    public IActionResult Login([FromBody]LoginRequest request)
    {
        try
        {
            var claims = new List<Claim> {new (ClaimTypes.Name, request.Login) };
            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)), SecurityAlgorithms.HmacSha256));
            
           // return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return Ok();
    }
}