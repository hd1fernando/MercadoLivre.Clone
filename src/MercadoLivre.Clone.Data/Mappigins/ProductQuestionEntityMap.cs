using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;

public class ProductQuestionEntityMap : ClassMap<ProductQuestionEntity>
{
    public ProductQuestionEntityMap()
    {
        Id(p => p.Id);
        Map(p => p.QuestionDate)
            .Not.Nullable();
        Map(p => p.Title)
            .Not.Nullable();

        References(p => p.Product)
            .Column("ProductId")
            .ForeignKey("Id");
        References(p => p.User)
            .Column("UserId")
            .ForeignKey("Id");

        Table("ProductQuestion");
    }
}
