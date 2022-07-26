using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductPurchaseCommandHandler : IRequestHandler<ProductPurchaseCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;
    private readonly IRepository<ProductPurchaseEntity, Guid> _productPurchaseRepository;

    public ProductPurchaseCommandHandler(
        IProductRepository productRepository,
        IMediator mediator,
        IRepository<ProductPurchaseEntity, Guid> productPurchaseRepository)
    {
        _productRepository = productRepository;
        _mediator = mediator;
        _productPurchaseRepository = productPurchaseRepository;
    }

    public async Task<Guid> Handle(ProductPurchaseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);

        product.SlaughterStock(request.Quantity);
        var productPurchase = new ProductPurchaseEntity(product, request.Quantity, request.Gateway);

        await _productPurchaseRepository.AddAsync(productPurchase, cancellationToken);
        await _productRepository.UpdateAsync(product, cancellationToken);

        return productPurchase.Id;
    }
}
