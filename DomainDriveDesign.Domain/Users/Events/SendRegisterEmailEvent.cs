using MediatR;

namespace DomainDriveDesign.Domain.Users.Events;

public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
{
    public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}