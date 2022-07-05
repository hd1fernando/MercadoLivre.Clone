using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;

public class ProductRepository : Repository<ProductEntity, int>, IProductRepository
{
    public ProductRepository(ISession session) : base(session)
    {
    }

    public Task<ProductEntity> FindBydNameAndCategoryAsync(string name, int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
