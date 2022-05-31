namespace MercadoLivre.Clone.Business.Repository;
public interface IRepository<TEntity>
{
    public Task<TEntity> GetAsync();
    public Task<IEnumerable<TEntity>> GetAllAsync();
}