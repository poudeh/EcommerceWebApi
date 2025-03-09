using Common.Application;

namespace Shop.Application.Comments.Create;

public record CreateCommentCommand(string text , long usedId , long productId):IBaseCommand;