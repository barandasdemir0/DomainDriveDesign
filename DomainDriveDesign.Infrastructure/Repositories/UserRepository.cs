using DomainDriveDesign.Domain.Users;
using DomainDriveDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriveDesign.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, email, password, country, city, street, postalCode, fullAddress);
        await _applicationDbContext.Users.AddAsync(user, cancellationToken);
        return user;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _applicationDbContext.Users.ToListAsync(cancellationToken);
    }
}
