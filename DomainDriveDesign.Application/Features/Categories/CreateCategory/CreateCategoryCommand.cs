using MediatR;

namespace DomainDriveDesign.Application.Features.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : IRequest;
