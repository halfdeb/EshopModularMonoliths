using Shared.Exception;

namespace Catalog.Products.Exception;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id)
        : base("Product", id)
    {
        
    } 
}