using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;
public class CategoryEntityMap : ClassMap<CategoryEntity>
{
    public CategoryEntityMap()
    {
        Id(c => c.Id);
        Map(c => c.Name)
            .Not.Nullable();

        Table("Category");
    }
}
