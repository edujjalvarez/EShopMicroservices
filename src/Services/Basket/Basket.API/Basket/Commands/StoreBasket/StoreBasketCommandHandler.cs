namespace Basket.API.Basket.Commands.StoreBasket;

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var cart = command.Cart;
        //TODO: store basket in database
        //TODO: update cache
        return new StoreBasketResult("foo");
    }
}
