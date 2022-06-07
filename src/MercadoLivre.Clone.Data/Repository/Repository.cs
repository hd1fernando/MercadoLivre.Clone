using MercadoLivre.Clone.Business.Repository;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{

    protected ISession _session;

    public Repository(ISession session)
    {
        _session = session;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        ITransaction transaction = null;
        try
        {
            transaction = _session.BeginTransaction();
            await _session.SaveAsync(entity, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction?.RollbackAsync(cancellationToken);
        }
        finally
        {
            transaction?.Dispose();
        }
    }


    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        => await _session.DeleteAsync(entity);

    public async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _session?.Dispose();
    }

    public Task<TEntity> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
