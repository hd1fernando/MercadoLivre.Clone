using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductPurchaseEntity : Entity<Guid>
{
    public virtual ProductEntity? Product { get; }
    public virtual int Quantity { get; }
    public virtual PaymentGateway Gateway { get; }

    [Obsolete("Apenas para uso do ORM.")]
    public ProductPurchaseEntity()
    {

    }

    public ProductPurchaseEntity(ProductEntity? product, int quantity, PaymentGateway gateway)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));
        Assert.Minimun(quantity, 1, $"Pelo menos um produto deve ser informado");

        Product = product;
        Quantity = quantity;
        Gateway = gateway;
    }

}
