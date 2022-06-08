using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface ICategoryRepository : IRepository<CategoryEntity, int>
{
    public Task<bool> CategoryAlreadyExistAsync(string name, CancellationToken cancellationToken);
}
