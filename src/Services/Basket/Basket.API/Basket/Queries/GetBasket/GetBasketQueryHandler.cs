namespace Basket.API.Basket.Queries.GetBasket;

public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        // TODO: get basket from database
        // var basket = await _repository.GetBasket(request.UserName);
        return new GetBasketResult(new ShoppingCart("foo"));
    }
}
