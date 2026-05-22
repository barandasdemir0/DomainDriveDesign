using DomainDriveDesign.Domain.Orders;
using DomainDriveDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriveDesign.Infrastructure.Repositories;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public OrderRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
    {
        Order order = new(
            Guid.NewGuid(),
            "1",
            DateTime.Now,
            OrderStatusEnum.AwaitingApproval
            );

        order.CreateOrder(createOrderDtos);

        await _applicationDbContext.Orders.AddAsync(order,cancellationToken);
        return order;

    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDbContext.Orders
            .Include(p=>p.OrderLines)!
            .ThenInclude(p=>p.Product)
            .ToListAsync(cancellationToken);
    }
}
