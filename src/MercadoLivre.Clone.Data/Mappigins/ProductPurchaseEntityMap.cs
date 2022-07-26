using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;

public class ProductPurchaseEntityMap : ClassMap<ProductPurchaseEntity>
{
    public ProductPurchaseEntityMap()
    {
        Id(x => x.Id);
        Map(x => x.Quantity)
            .Not.Nullable();
        Map(x => x.Gateway)
            .Not.Nullable();

        References(x => x.Product)
            .Column("ProductId")
            .ForeignKey("Id");

        Table("ProductPurchase");
    }
}
