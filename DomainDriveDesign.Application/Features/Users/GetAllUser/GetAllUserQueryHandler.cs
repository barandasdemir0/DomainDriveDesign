using DomainDriveDesign.Domain.Users;
using MediatR;

namespace DomainDriveDesign.Application.Features.Users.GetAll;

internal sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }
}

