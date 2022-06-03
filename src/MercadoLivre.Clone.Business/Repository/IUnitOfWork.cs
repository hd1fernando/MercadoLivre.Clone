namespace MercadoLivre.Clone.Business.Repository;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
    Task Rollback();
}