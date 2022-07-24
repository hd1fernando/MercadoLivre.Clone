using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;

namespace MercadoLivre.Clone.Data.Repository;

public class ProductReivewRepository : Repository<ProductReviewEntity, int>, IProductReivewRepository
{
    public ProductReivewRepository(ISession session) : base(session)
    {
    }

    public IEnumerable<ProductReviewEntity> FindByProductId(int productId)
        => Session.Query<ProductReviewEntity>()
            .Where(x => x.Product.Id == productId);

    public async Task<ProductReviewEntity> FindByProductIdAndUserAsync(int productId, string userName, CancellationToken cancellationToken)
        => await Session.Query<ProductReviewEntity>()
            .Fetch(p => p.Product)
            .Fetch(p => p.User)
            .FirstOrDefaultAsync(p => p.Product.Id == productId && p.User.UserName == userName, cancellationToken);
}
