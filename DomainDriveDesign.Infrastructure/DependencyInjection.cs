using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Categories;
using DomainDriveDesign.Domain.Orders;
using DomainDriveDesign.Domain.Products;
using DomainDriveDesign.Domain.Users;
using DomainDriveDesign.Infrastructure.Context;
using DomainDriveDesign.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDriveDesign.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork>(opt=>opt.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }

   
}
