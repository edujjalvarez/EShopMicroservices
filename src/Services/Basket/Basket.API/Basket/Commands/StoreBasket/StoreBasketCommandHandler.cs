using Discount.gRPC;

namespace Basket.API.Basket.Commands.StoreBasket;

public class StoreBasketCommandHandler(
    IBasketRepository repository,
    DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await ApplyDiscount(command.Cart, cancellationToken);

        // Store basket in database (use Marte upsert - if exist = update, if not exist = insert) and Update Cache
        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }

    private async Task ApplyDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        // Communicate with Discount.gRPC and calculate latest prices of products into sc
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}
