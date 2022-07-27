using MediatR;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Events
{
    public class ProductPurchaseEvent : INotification
    {
        public ProductPurchaseEvent(ProductEntity product, UserEntity consumer)
        {
            Product = product;
            Consumer = consumer;
        }

        public ProductEntity Product { get; }
        public UserEntity Consumer { get; }

    }
}
