namespace Basket.API.Basket.Commands.StoreBasket;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(c => c.Cart)
            .NotNull()
            .WithMessage("Cart can not be null");
        RuleFor(c => c.Cart.UserName)
            .NotEmpty()
            .WithMessage("UserName is required");
    }
}
