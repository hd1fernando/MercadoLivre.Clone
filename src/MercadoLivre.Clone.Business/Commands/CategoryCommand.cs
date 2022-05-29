using MediatR;

namespace MercadoLivre.Clone.Business.Commands
{
    public class CategoryCommand : CommandBase
    {
        public string? Name { get; }
        public int CategoryId { get; }

    }
}
