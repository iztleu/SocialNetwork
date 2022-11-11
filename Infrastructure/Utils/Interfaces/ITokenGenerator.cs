namespace SocialNetwork.Utils.Interfaces;

public interface ITokenGenerator
{
    public string CreateToken(string email);
}