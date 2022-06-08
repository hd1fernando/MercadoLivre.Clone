using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.CommandHandlers
{
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
            if (request.CategoryId != default)
            {
                var categoryParent = await _categoryRepository.FindByIdAsync(request.CategoryId, cancellationToken);
                categoryEntity = new CategoryEntity(request.Name, categoryParent);
            }
            else
            {
                categoryEntity = new CategoryEntity(request.Name);
            }

            await _categoryRepository.AddAsync(categoryEntity, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
