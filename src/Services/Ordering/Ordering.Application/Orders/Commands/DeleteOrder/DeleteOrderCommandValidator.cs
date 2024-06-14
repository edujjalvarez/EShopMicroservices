using FluentValidation;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}
