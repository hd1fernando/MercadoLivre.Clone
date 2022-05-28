using MediatR;

namespace MercadoLivre.Clone.Business.Commands
{
    public class CategoryCommandHandler : IRequestHandler<CategoryCommand>
    {
        public Task<Unit> Handle(CategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
