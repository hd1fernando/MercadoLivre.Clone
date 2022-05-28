using MediatR;

namespace MercadoLivre.Clone.Business.Commands
{
    public class CategoryCommand : IRequest
    {

        public string? Name { get; }
        public int CategoryId { get; }

        public CategoryCommand(string? name)
        {
            Name = name;
        }

        public CategoryCommand(string? name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

    }
}
