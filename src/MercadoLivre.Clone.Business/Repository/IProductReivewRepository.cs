using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface IProductReivewRepository : IRepository<ProductReviewEntity, int>
{
    public Task<ProductReviewEntity> FindByProductIdAndUserAsync(int productId, string userName, CancellationToken cancellationToken);
}
