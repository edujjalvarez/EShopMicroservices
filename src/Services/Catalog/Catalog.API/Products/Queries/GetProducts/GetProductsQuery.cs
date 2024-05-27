namespace Catalog.API.Products.Queries.GetProducts;

public record GetProductsQuery(
    int? PageNumber = 1,
    int? PageSize = 10) : IQuery<GetProductsResult>;
