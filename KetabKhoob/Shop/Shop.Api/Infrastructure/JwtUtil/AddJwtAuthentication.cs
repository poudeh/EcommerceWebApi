using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Api.Infrastructure.JwtUtil;


public static class JwtAuthenticationConfig //Jwt Setting
{

    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(option =>
        {
            option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"])),
                ValidIssuer = configuration["JwtConfig:Issuer"],
                ValidAudience = configuration["JwtConfig:Audience"],
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true
            };

            option.SaveToken = true;

            //Custom jwt Options To override:
            option.Events = new JwtBearerEvents()
            {
                OnTokenValidated = async context =>
                {
                    var customValidate = context.HttpContext.RequestServices.GetRequiredService<CustomJwtValidation>();
                    await customValidate.Validate(context);



                }

            };


        });
    }
}

//The way That Jwt goes to recieve
//OnChallenge = context =>
//{
//    return Task.CompletedTask;
//},
//OnMessageReceived = context =>
//{
//    return Task.CompletedTask;
//},
//When Token Comes To our system and its valid What Should Do?