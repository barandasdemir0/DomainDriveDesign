using DomainDriveDesign.Application.Features.Orders.CreateOrder;
using DomainDriveDesign.Application.Features.Orders.GetAllOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriveDesign.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
