using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Users;
using DomainDriveDesign.Domain.Users.Events;
using MediatR;

namespace DomainDriveDesign.Application.Features.Users.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        //iş kuralları koyabiliriz buraya
        var user = await _userRepository.CreateAsync(
            request.Name,
            request.Email,
            request.Password,
            request.Country,
            request.City,
            request.Street,
            request.PostalCode,
            request.FullAddress,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

       await _mediator.Publish(new UserDomainEvent(user));


    }
}
