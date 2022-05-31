using MercadoLivre.Clone.Business.Repository;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;
public class UnitOfWOrk : IUnitOfWork
{
    private static ISessionFactory SessionFactory => null;

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}