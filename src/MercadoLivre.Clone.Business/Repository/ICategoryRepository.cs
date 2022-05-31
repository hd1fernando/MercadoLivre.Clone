using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface ICategoryRepository : IRepository<CategoryEntity>
{
    public Task<bool> CategoryAlreadyExistAsync(string name, CancellationToken cancellationToken);
}
