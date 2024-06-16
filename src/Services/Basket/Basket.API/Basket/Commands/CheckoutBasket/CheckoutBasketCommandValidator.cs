namespace Basket.API.Basket.Commands.CheckoutBasket;

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(c => c.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto can't be null");
        RuleFor(c => c.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
