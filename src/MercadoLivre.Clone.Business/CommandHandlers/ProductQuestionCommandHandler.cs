using MediatR;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductQuestionCommandHandler : IRequestHandler<ProductQuestionCommand>
{
    public Task<Unit> Handle(ProductQuestionCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
