using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.CommandHandlers;

// CI: 5
public class CategoryCommandHandler : IRequestHandler<CategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    // 2
    public CategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    // 1
    public async Task<Unit> Handle(CategoryCommand request, CancellationToken cancellationToken)
    {
        //1
        CategoryEntity categoryEntity = new CategoryEntity(request.Name);

        // 1
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
