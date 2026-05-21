namespace DomainDriveDesign.Domain.Orders;

public interface IOrderReoısitory
{
    Task CreateAsync(List<CreateOrderDto> createOrderDtos,CancellationToken cancellationToken=default);
    Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
}
