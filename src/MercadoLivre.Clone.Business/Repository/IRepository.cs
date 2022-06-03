namespace MercadoLivre.Clone.Business.Repository;
public interface IRepository<TEntity> where TEntity : class
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<TEntity> FindByIdAsync(TEntity entity, CancellationToken cancellationToken);
    public Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken);
}
