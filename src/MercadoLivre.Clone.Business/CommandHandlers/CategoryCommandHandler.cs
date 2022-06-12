using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.CommandHandlers;
public class CategoryCommandHandler : IRequestHandler<CategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CategoryCommand request, CancellationToken cancellationToken)
    {
        CategoryEntity categoryEntity = null;
        categoryEntity = new CategoryEntity(request.Name);

        if (request.CategoryId != default)
        {
            var categoryParent = await _categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);
            categoryEntity.AddParent(categoryParent);
        }

        await _categoryRepository.AddAsync(categoryEntity, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return Unit.Value;
    }
}
