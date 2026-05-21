using DomainDriveDesign.Domain.Products;
using MediatR;

namespace DomainDriveDesign.Application.Features.Products.GetAllProduct;

internal sealed class GetAllProductCommandHandler : IRequestHandler<GetAllProductCommand, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetAllProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync(cancellationToken);
    }
}
