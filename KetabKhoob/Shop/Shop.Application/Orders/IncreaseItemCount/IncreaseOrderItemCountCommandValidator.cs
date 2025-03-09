using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount;

public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
{
    public IncreaseOrderItemCountCommandValidator()
    {
        RuleFor(f => f.count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}