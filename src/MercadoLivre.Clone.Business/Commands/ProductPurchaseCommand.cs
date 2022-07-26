using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Commands
{
    public class ProductPurchaseCommand : CommandBase<Guid>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public PaymentGateway Gateway { get; set; }
    }
}
