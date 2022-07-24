using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;

public class ProductQuestionRepository : Repository<ProductQuestionEntity, int>, IProductQuestionRepository
{
    public ProductQuestionRepository(ISession session) : base(session)
    {
    }

    public IEnumerable<ProductQuestionEntity> FindByProductId(int productId)
        => Session.Query<ProductQuestionEntity>()
            .Where(x => x.Product.Id == productId);
}
