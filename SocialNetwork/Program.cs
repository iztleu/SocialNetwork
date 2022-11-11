using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using SocialNetwork.DI;
using SocialNetwork.Utils.Configuration;

const string ISSUER = "MyAuthServer"; // издатель токена
const string AUDIENCE = "MyAuthClient"; // потребитель токена

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
// Serilog configuration        
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
// Register Serilog
builder.Logging.AddSerilog(logger);

var tokenConfig = new TokenGeneratorConfiguration();
builder.Configuration.GetSection("TokenGeneratorConfiguration").Bind(tokenConfig);
// Add services to the container.

builder.Services.InitializeDependencies(builder.Environment, builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = ISSUER,
            ValidateAudience = true,
            ValidAudience = AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfig.SecurityKey)),
            ValidateIssuerSigningKey = true
        };
        // options.Events = new JwtBearerEvents { OnMessageReceived = CustomOnMessageReceivedHandler.OnMessageReceived };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


public static class CustomOnMessageReceivedHandler
{
    public static Task OnMessageReceived(MessageReceivedContext context)
    {
        string authorization = context.Request.Headers["Authorization"];

        // If no authorization header found, nothing to process further
        if (string.IsNullOrEmpty(authorization))
        {
            context.NoResult();
            return Task.CompletedTask;
        }

        context.Token = authorization;
     
        // If no token found, no further work possible
        if (string.IsNullOrEmpty(context.Token))
        {
            context.NoResult();
        }

        return Task.CompletedTask;
    }
}