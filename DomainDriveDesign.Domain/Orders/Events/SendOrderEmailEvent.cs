using MediatR;

namespace DomainDriveDesign.Domain.Orders.Events;

public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
       return Task.CompletedTask;
    }
}
