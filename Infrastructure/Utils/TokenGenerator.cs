using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Utils.Configuration;
using SocialNetwork.Utils.Interfaces;

namespace SocialNetwork.Utils;

public class TokenGenerator: ITokenGenerator
{
    private readonly TokenGeneratorConfiguration _config;


    public TokenGenerator(TokenGeneratorConfiguration config)
    {
        _config = config;
    }
 
    public string CreateToken(string email)
    {
        var claims = new List<Claim> {new (ClaimTypes.Name, email) };
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecurityKey)), SecurityAlgorithms.HmacSha256));
            
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}