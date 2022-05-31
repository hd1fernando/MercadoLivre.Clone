namespace MercadoLivre.Clone.Business.Repository;
public interface IRepository<TEntity>
{
    public Task AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(TEntity entity);
    public Task<TEntity> FindByIdAsync(TEntity entity);
    public Task<IEnumerable<TEntity>> FindAllAsync();
}
