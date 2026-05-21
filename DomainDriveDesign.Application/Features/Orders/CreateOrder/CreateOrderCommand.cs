using DomainDriveDesign.Domain.Orders;
using MediatR;

namespace DomainDriveDesign.Application.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(List<CreateOrderDto> createOrderDtos) : IRequest;
