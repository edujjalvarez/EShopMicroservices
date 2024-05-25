using BuildingBlocks.CQRS;

namespace Catalog.API.Products.Commands.CreateProduct;

public record CreateProductCommand(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;
