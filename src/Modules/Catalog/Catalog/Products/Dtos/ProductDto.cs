namespace Catalog.Products.Dtos
{
    public record ProductDto(Guid id, string name, List<string> categories, string description, string imageFile, decimal price);
}
