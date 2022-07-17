using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;

public class ProductImageEntityMap : ClassMap<ProductImageEntity>
{
    public ProductImageEntityMap()
    {
        Id(p => p.Id);

        Map(p => p.Path)
            .Not.Nullable();

        References(p => p.Product)
            .Column("ProductId")
            .ForeignKey("Id");

        Table("ProductImage");
    }
}
