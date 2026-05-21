using DomainDriveDesign.Domain.Abstraction;
using DomainDriveDesign.Domain.Products;
using MediatR;

namespace DomainDriveDesign.Application.Features.Products.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.CreateAsync(
            request.Name,
            request.Quantity,
            request.Amount,
            request.Currency,
            request.CategoryId,
            cancellationToken);

         await _unitOfWork.SaveChangesAsync(cancellationToken);


    }
}