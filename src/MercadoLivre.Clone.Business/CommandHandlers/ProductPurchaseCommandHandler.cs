using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Events;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductPurchaseCommandHandler : IRequestHandler<ProductPurchaseCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IMediator _mediator;
    private readonly IRepository<ProductPurchaseEntity, Guid> _productPurchaseRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUser _user;


    public ProductPurchaseCommandHandler(
        IProductRepository productRepository,
        IMediator mediator,
        IRepository<ProductPurchaseEntity, Guid> productPurchaseRepository,
        IUserRepository userRepository,
        IUser user)
    {
        _productRepository = productRepository;
        _mediator = mediator;
        _productPurchaseRepository = productPurchaseRepository;
        _userRepository = userRepository;
        _user = user;
    }

    public async Task<Guid> Handle(ProductPurchaseCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);

        product.SlaughterStock(request.Quantity);
        var productPurchase = new ProductPurchaseEntity(product, request.Quantity, request.Gateway);

        await _productPurchaseRepository.AddAsync(productPurchase, cancellationToken);
        await _productRepository.UpdateAsync(product, cancellationToken);

        var userConsumer = await _userRepository.FindByUserEmailAsync(_user.GetUserEmail(), cancellationToken);
        var @event = new ProductPurchaseEvent(product, userConsumer);

        await _mediator.Publish(@event, cancellationToken);

        return productPurchase.Id;
    }
}
