using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Products;
using DomainDriveDesign.Domain.Shared;

namespace DomainDriveDesign.Domain.Categories;

public sealed class Category : Entity
{
    public Category(Guid id,Name name):base(id)
    {
        Name = name;
    }

    public Name Name { get; private set; }
    public ICollection<Product>? Products { get; private set; }

    public void ChangeName(string name)
    {
        Name = new(name);
    }
}
