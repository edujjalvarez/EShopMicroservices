﻿namespace Catalog.API.Products.Queries.GetProductById;

internal class GetProductByIdQueryHandler(
    IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null)
            throw new ProductNotFoundException(query.Id);
        return new GetProductByIdResult(product);
    }
}
