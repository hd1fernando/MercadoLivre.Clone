using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;
public class CategoryMap : ClassMap<CategoryEntity>
{
    public CategoryMap()
    {
        Id(c => c.Id);
        Map(c => c.Name)
            .Unique()
            .Not.Nullable();
    }
}
