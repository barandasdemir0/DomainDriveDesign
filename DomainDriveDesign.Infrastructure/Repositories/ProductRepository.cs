using DomainDriveDesign.Domain.Products;
using DomainDriveDesign.Domain.Shared;
using DomainDriveDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriveDesign.Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProductRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
    {
        Product product = new(Guid.NewGuid(), new(name), quantity, new(amount, Currency.FromCode(currency)), categoryId);

        await _applicationDbContext.Products.AddAsync(product, cancellationToken);
    }

    public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Products.ToListAsync(cancellationToken);
    }
}
