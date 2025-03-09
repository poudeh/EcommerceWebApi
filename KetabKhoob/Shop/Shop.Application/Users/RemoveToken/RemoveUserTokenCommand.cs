using Common.Application;

namespace Shop.Application.Users.RemoveToken;

public record RemoveUserTokenCommand(long userId , long TokenId):IBaseCommand<string>;