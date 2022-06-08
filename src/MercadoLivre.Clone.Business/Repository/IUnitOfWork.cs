namespace MercadoLivre.Clone.Business.Repository;

public interface IUnitOfWork : IDisposable
{
    public Task<bool> Commit(CancellationToken cancellationToken);
    public Task Rollback(CancellationToken cancellationToken);
}