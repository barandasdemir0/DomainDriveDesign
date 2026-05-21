using MediatR;

namespace DomainDriveDesign.Domain.Users.Events;

public class UserDomainEvent:INotification
{
    public User User { get;}
    public UserDomainEvent(User user)
    {
        User = user;
    }
}
