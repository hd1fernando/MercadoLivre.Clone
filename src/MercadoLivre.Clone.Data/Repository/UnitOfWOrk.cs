using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;

namespace MercadoLivre.Clone.Data.Repository;
public class UnitOfWOrk : IUnitOfWork
{
    private ISession _session;
    private ITransaction _transaction;
    private ISessionFactory _sessionFactory;

    public UnitOfWOrk(ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;
        _session = _sessionFactory.OpenSession();
        _transaction = _session.BeginTransaction();
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }

    public void Dispose()
    {
        _transaction.Dispose();
        //_transaction = null;
    }

    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
    }
}

public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(ISession session) : base(session)
    {
    }

    ~CategoryRepository()
        => Dispose();

    public async Task<bool> CategoryAlreadyExistAsync(string name, CancellationToken cancellationToken)
    {
        var result = await _session.Query<CategoryEntity>()
            .Where(x => x.Name == name)
            ?.FirstOrDefaultAsync(cancellationToken);

        return result is not null;
    }

}
