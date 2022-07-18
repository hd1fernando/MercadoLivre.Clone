using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;

public class ProductReviewEntityMap : ClassMap<ProductReviewEntity>
{
    public ProductReviewEntityMap()
    {
        Id(x => x.Id);
        Map(x => x.Rate)
            .Not.Nullable();
        Map(x => x.Description)
            .Not.Nullable()
            .Length(500);
        Map(x => x.Title)
            .Not.Nullable();
        References(x => x.Product)
            .Column("ProductId")
            .ForeignKey("Id");
        References(x => x.User)
            .Columns("UserId")
            .ForeignKey("Id");

        Table("ProductReview");
    }
}
