using Basket.API.Data;

namespace Basket.API.Basket.Queries.GetBasket;

public class GetBasketQueryHandler(
    IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(request.UserName, cancellationToken);
        return new GetBasketResult(basket);
    }
}
