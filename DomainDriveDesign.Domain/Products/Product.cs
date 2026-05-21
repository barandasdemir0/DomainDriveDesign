using DomainDriveDesign.Domain.Categories;

namespace DomainDriveDesign.Domain.Products;

public sealed class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
