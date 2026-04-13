namespace Catalog.Products.Exceptions
{
    public class ProductNotFoundExcption(Guid id) : NotFoundException("Product", id)
    {
    }
}
