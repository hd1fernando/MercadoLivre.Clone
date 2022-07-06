using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface IProductRepository : IRepository<ProductEntity, int>
{
    public Task<ProductEntity> FindBydNameAndCategoryAsync(string name, int categoryId, Guid ownerId, CancellationToken cancellationToken);
}
