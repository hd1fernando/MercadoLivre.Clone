using MediatR;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Business.CommandHandlers;
public class ProductCommandHandler : IRequestHandler<ProductCommand>
{
    public Task<Unit> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
