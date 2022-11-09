using Microsoft.Extensions.Options;
using SocialNetwork.Utils;
using SocialNetwork.Utils.Configuration;
using SocialNetwork.Utils.Interfaces;

namespace SocialNetwork.DI;

public static class DiExtension
{
    public static void InitializeDependencies(this IServiceCollection services, IWebHostEnvironment environment,
        IConfiguration configuration)
    {
        services.Configure<TokenGeneratorConfiguration>(options => configuration.GetSection("TokenGeneratorConfiguration").Bind(options));
        services.AddSingleton(x => x.GetRequiredService<IOptions<TokenGeneratorConfiguration>>().Value);

        services.AddTransient<ITokenGenerator, TokenGenerator>();
    }
}