using DomainDriveDesign.Domain.Products;
using MediatR;

namespace DomainDriveDesign.Application.Features.Products.GetAllProduct;

public sealed record GetAllProductCommand() : IRequest<List<Product>>;
