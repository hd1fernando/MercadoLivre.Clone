using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;
public interface IRepository<TEntity, TKey> 
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken);
    public Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken);
}
