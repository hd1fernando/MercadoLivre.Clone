using MediatR;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductPurchaseCommandHandler : IRequestHandler<ProductPurchaseCommand, Guid>
{
    public Task<Guid> Handle(ProductPurchaseCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Guid.Empty);
    }
}
