namespace Catalog.API.Products.Queries.GetProducts;

public record GetProductsRequest(
    int? PageNumber = 1,
    int? PageSize = 10);
