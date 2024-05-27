namespace Catalog.API.Products.Commands.DeleteProduct;

public record DeleteProductCommand(
    Guid Id) : ICommand<DeleteProductResult>;
