using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.CommandHandlers
{
    public class CategoryCommandHandler : IRequestHandler<CategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.CategoryId == default
               ? new CategoryEntity(request.Name)
               : new CategoryEntity(request.Name, request.CategoryId);

            await _categoryRepository.AddAsync(category, cancellationToken);

            return Unit.Value;
        }
    }
}
