using MediatR;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductImageCommandHandler : IRequestHandler<ProductImageCommand>
{
    public Task<Unit> Handle(ProductImageCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
