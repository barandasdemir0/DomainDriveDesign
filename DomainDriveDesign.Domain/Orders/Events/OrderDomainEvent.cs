using MediatR;

namespace DomainDriveDesign.Domain.Orders.Events;

public sealed class OrderDomainEvent:INotification
{
    public Order Order { get; set; }
    public OrderDomainEvent(Order order)
    {
        Order = order;
    }
}
