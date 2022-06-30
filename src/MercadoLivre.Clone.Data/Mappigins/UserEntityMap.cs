using FluentNHibernate.Mapping;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Data.Mappigins;

public class UserEntityMap : ClassMap<UserEntity>
{
    public UserEntityMap()
    {
        Id(x => x.Id);
        Map(x => x.Email)
            .Not.Nullable();
        Map(x => x.UserName)
            .Not.Nullable();

        Table("AspNetUsers");
    }
}
