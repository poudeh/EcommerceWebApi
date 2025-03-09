using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create;

public class CreateCommentCommandValidator:AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(r => r.text)
            .NotNull()
            .NotEmpty()
            .MinimumLength(5)
            .WithMessage(ValidationMessages.maxLength("متن نظر",5));
    }
}