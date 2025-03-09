using Shop.Api.Infrastructure.JwtUtil;

namespace Shop.Api.Infrastructure;

public static class DependencyRegister
{
    public static void RegisterApiDependency(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(MapperProfile).Assembly);
        service.AddTransient<CustomJwtValidation>();

        //Which sites can connect to this.
        service.AddCors(options =>
        {
            options.AddPolicy(name: "ShopApi",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }


}