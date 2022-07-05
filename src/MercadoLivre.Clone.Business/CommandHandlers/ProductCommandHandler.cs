using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;

namespace MercadoLivre.Clone.Business.CommandHandlers;

// CI: 4
public class ProductCommandHandler : IRequestHandler<ProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUser _user;

    // 4
    public ProductCommandHandler(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork,
        ICategoryRepository categoryRepository,
        IUserRepository userRepository, IUser user)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _user = user;
    }

    public async Task<Unit> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);
        var user = await _userRepository.FindByUserEmailAsync(_user.GetUserEmail(), cancellationToken);

        var product = new ProductEntity(
            request.Name,
            request.Price,
            request.AvailableQuantity,
            request.Features,
            request.Description,
            category,
            user);

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
