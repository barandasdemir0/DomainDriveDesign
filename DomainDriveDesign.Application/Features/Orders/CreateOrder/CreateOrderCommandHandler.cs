using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Orders;
using DomainDriveDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDriveDesign.Application.Features.Orders.CreateOrder;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
        _mediator = mediator;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order =  await _orderRepository.CreateAsync(request.createOrderDtos, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new OrderDomainEvent(order));
    }
}