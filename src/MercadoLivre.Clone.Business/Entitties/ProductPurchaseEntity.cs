using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductPurchaseEntity : Entity<Guid>
{
    public ProductEntity? Product { get; }
    public int Quantity { get; }
    public PaymentGateway Gateway { get; }

    public ProductPurchaseEntity(ProductEntity? product, int quantity, PaymentGateway gateway)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));
        Assert.Minimun(quantity, 1, $"Pelo menos um produto deve ser informado");

        Product = product;
        Quantity = quantity;
        Gateway = gateway;
    }


}
