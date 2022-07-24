using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface IProductImageRepository : IRepository<ProductImageEntity, int>
{
    public IEnumerable<ProductImageEntity> FindByProductId(int productId);
}
