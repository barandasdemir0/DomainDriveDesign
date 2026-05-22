using DomainDriveDesign.Domain.Categories;
using DomainDriveDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriveDesign.Infrastructure.Repositories;

internal sealed class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        Category category = new(Guid.NewGuid(),new(name));
        await _applicationDbContext.AddAsync(category,cancellationToken);
        

    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Categories.ToListAsync(cancellationToken);
    }
}
