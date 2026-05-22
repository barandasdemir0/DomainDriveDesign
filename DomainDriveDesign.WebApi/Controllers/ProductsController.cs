using DomainDriveDesign.Application.Features.Products.CreateProduct;
using DomainDriveDesign.Application.Features.Products.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriveDesign.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
