using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Products;

namespace DomainDriveDesign.Domain.Categories;

public sealed class Category : Entity
{
    public Category(Guid id) : base(id)
    {
    }

    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
