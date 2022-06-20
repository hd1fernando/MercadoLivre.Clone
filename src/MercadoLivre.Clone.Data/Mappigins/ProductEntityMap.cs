using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;

public class ProductEntityMap : ClassMap<ProductEntity>
{
    public ProductEntityMap()
    {
        Id(p => p.Id);
        Map(p => p.Name)
            .Not.Nullable();
        Map(p => p.Price)
            .Not.Nullable();
        Map(p => p.Features)
            .Not.Nullable();
        Map(p => p.Description)
            .Not.Nullable()
            .Length(1000);
        Map(p => p.AvailableQuantity)
            .Not.Nullable();
        Map(p => p.Instant)
            .Not.Nullable();

        References(p => p.Category)
            .Column("CategoryId")
            .ForeignKey("Id");

        Table("Product");
    }
}
