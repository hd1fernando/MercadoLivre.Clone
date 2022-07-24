using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;

public class ProductImageRepository : Repository<ProductImageEntity, int>, IProductImageRepository
{
    public ProductImageRepository(ISession session) : base(session)
    {
    }

    public IEnumerable<ProductImageEntity> FindByProductId(int productId)
        => Session.Query<ProductImageEntity>()
            .Where(x => x.Product.Id == productId);
}
