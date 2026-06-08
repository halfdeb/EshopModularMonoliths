namespace Catalog.Products.Features.GetProduct;

public record GetProductQuery()
    : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<ProductDto> Products);


internal class GetProductHandler(CatalogDbContext dbContext) 
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);
        
        //mapping product entity to ProductDto using Mapster
        var productDtos = products.Adapt<List<ProductDto>>();

        return new GetProductResult(productDtos);
    }
}