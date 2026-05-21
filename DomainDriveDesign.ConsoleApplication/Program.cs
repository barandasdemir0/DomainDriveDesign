using MediatR;

namespace DomainDriveDesign.ConsoleApplication;

internal class Program
{
    static void Main(string[] args)
    {
        //Order order = new();
        //order.CreateOrder(1, "domates");
        //order.CreateOrder(2, "Elma");
        //order.CreateOrder(3, "Armut");

        //DomainEventDispacther.Dispatch(order.DomainEvents);


        Console.ReadLine();
    }

    public class Order
    {
        private readonly IMediator _mediator;

        public Order(IMediator mediator)
        {
            _mediator = mediator;
        }

        public int Id { get; set; }
        public string? ProductName { get; set; }

        public List<IDomainEvent> DomainEvents { get; } = new();

        public void CreateOrder(int id,string productName)
        {
            Id = id;
            ProductName = productName;

            //bazı işlemler tetiklensin
            //DomainEvents.Add(new OrderCreatedEvent(id));

            _mediator.Publish(new OrderCompletedEvent(id));
        }
    }

    public class SendMailHandler : INotificationHandler<OrderCompletedEvent>
    {
        Task INotificationHandler<OrderCompletedEvent>.Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            //mail gönderme işlemi
            return Task.CompletedTask;
        }
    }
    public class SendSmsHandler : INotificationHandler<OrderCompletedEvent>
    {
        Task INotificationHandler<OrderCompletedEvent>.Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            //sms gönderme işlemi
            return Task.CompletedTask;
        }
    }

    public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent>
    {
        Task INotificationHandler<OrderCompletedEvent>.Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    public class OrderCompletedEvent : INotification
    {
        public int Id { get; }
        public OrderCompletedEvent(int id)
        {
            Id = id;
        }
    }


    public static class DomainEventDispacther
    {
        public static void Dispatch(List<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                if (domainEvent is OrderCreatedEvent orderEvent)
                {
                    Console.WriteLine($"order event işlemine başladı, Id:{orderEvent.OrderId}");
                }
            }
        }
    }

    public interface IDomainEvent
    {

    }

    public class OrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get; }
        public OrderCreatedEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
