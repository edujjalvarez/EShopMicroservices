using FluentValidation;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.Order.OrderName).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(c => c.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be empty");
    }
}
