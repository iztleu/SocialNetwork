using Core.Services;
using Core.Services.Interfaces;
using Data.Services;
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
        var connectionString = configuration.GetConnectionString("DatabaseConnection");
        services.Configure<TokenGeneratorConfiguration>(options => configuration.GetSection("TokenGeneratorConfiguration").Bind(options));
        services.AddSingleton(x => x.GetRequiredService<IOptions<TokenGeneratorConfiguration>>().Value);
        services.AddTransient<ITokenGenerator, TokenGenerator>();
        services.AddTransient<IUserRepository, UserRepository>(_ => new UserRepository(connectionString));
        services.AddTransient<IUserHandler, UserHandler>();
        services.AddTransient<IArticlesRepository, ArticlesRepository>(_ => new ArticlesRepository(connectionString));
        services.AddTransient<IArticlesHandler, ArticlesHandler>();
    }
}