using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Infrastructure.JwtUtil;

public class CustomJwtValidation
{
    private readonly IUserFacade _userFacade;

    public CustomJwtValidation(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }

    public async Task Validate(TokenValidatedContext context) //TokenValidatedContext is the Context in page AddJwtAuthentication
    {
        var userId = context.Principal.GetUserId(); //Recevie userId via Claims
        var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var token = await _userFacade.GetUserTokenByJwtToken(jwtToken);
        if (token == null)
        {
            context.Fail("Token not found");
            return;
        }

        var user = await _userFacade.GetUserById(userId);
        if (user==null || user.IsActive == false)
        {
            context.Fail("User is Inactive");
            return;
        }




    }
}