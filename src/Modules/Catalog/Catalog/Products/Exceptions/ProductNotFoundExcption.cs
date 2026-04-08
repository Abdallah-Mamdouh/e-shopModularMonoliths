namespace Catalog.Products.Exceptions
{
    public class ProductNotFoundExcption : NotFoundException
    {
        public ProductNotFoundExcption(Guid id) : base("Product", id)
        {
        }
    }
}
