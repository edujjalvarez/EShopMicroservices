namespace Catalog.API.Products.Queries.GetProductsByCategory;

internal class GetProductsByCategoryQueryHandler(
    IDocumentSession session) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Categories.Contains(query.Category))
            .ToListAsync(cancellationToken);
        return new GetProductsByCategoryResult(products);
    }
}
