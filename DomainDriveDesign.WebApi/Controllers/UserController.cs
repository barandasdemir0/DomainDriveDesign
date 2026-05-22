using DomainDriveDesign.Application.Features.Users.CreateUser;
using DomainDriveDesign.Application.Features.Users.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDriveDesign.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
