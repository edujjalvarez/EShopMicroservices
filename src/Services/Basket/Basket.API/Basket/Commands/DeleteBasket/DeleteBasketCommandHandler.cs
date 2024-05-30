namespace Basket.API.Basket.Commands.DeleteBasket;

public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO: delete basket from database and cache
        // session.Delete<Product>(command.Id);
        return new DeleteBasketResult(true);
    }
}
