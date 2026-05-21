using DomainDriveDesign.Domain.Categories;
using MediatR;

namespace DomainDriveDesign.Application.Features.Categories.GetAllCategory;

public sealed record GetAllCategoryQuery() : IRequest<List<Category>>;
