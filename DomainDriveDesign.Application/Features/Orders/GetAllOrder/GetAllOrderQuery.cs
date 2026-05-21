using DomainDriveDesign.Domain.Orders;
using MediatR;

namespace DomainDriveDesign.Application.Features.Orders.GetAllOrder;

public sealed record GetAllOrderQuery() : IRequest<List<Order>>;

