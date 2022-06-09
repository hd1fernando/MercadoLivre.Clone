using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;

namespace MercadoLivre.Clone.Data.Repository;

public class NHibernateRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    protected ISession Session;

    public NHibernateRepository(ISession session)
    {
        Session = session;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Session.SaveAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Session.DeleteAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken)
    {
        return await Session.Query<TEntity>().ToListAsync();
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await Session.UpdateAsync(entity, cancellationToken);
    }

    public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await Session.Query<TEntity>()
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }
}

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{

    protected readonly NHibernateContext Context;

    public Repository(NHibernateContext context)
    {
        Context = context;
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.BeginTransaction();
        await Context.Session.SaveAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.BeginTransaction();
        await Context.Session.DeleteAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken)
    {
        Context.BeginTransaction();
        return await Context.Session.Query<TEntity>().ToListAsync();
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.BeginTransaction();
        await Context.Session.UpdateAsync(entity, cancellationToken);
    }

    public async Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        Context.BeginTransaction();
        return await Context.Session.Query<TEntity>()
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }
}
