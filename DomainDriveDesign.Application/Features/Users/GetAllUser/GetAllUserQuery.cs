using DomainDriveDesign.Domain.Users;
using MediatR;

namespace DomainDriveDesign.Application.Features.Users.GetAll;

public sealed record GetAllUserQuery() : IRequest<List<User>>;

