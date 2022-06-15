using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.CommandHandlers;
public class ProductCommandHandler : IRequestHandler<ProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);
        var product = new ProductEntity(request.Name, request.Price, request.AvailableQuantity, request.Features, request.Description, category);

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
