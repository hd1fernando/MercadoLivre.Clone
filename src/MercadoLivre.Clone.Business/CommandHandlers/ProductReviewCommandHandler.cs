using MediatR;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductReviewCommandHandler : IRequestHandler<ProductReviewCommand>
{
    public Task<Unit> Handle(ProductReviewCommand request, CancellationToken cancellationToken)
    {

        return Unit.Value;
    }
}
