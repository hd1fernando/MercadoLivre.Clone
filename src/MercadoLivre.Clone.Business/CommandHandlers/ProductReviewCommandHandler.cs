using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductReviewCommandHandler : IRequestHandler<ProductReviewCommand>
{
    private readonly IRepository<ProductReviewEntity, int> _productReviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUser _user;

    public ProductReviewCommandHandler(
        IRepository<ProductReviewEntity, int> productReviewRepository,
        IUserRepository userRepository,
        IProductRepository productRepository,
        IUser user)
    {
        _productReviewRepository = productReviewRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _user = user;
    }

    public async Task<Unit> Handle(ProductReviewCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);

        var loggedUser = await _userRepository.FindByUserEmailAsync(_user.GetUserEmail(), cancellationToken);

        var productReivew = new ProductReviewEntity(request.Rate, request.Title, request.Description, product, loggedUser);

        await _productReviewRepository.AddAsync(productReivew, cancellationToken);

        return Unit.Value;
    }
}
