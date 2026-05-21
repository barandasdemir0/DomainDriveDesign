using MediatR;

namespace DomainDriveDesign.Domain.Orders.Events;

public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
       return Task.CompletedTask;
    }
}
