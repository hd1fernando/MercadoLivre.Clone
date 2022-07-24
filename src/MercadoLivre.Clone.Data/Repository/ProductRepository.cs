using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;

namespace MercadoLivre.Clone.Data.Repository;

// CI:  3
public class ProductRepository : Repository<ProductEntity, int>, IProductRepository
{
    public ProductRepository(ISession session) : base(session)
    {
    }

    // 2
    public async Task<ProductEntity> FindBydNameAndCategoryAsync(string name, int categoryId, Guid ownerId, CancellationToken cancellationToken)
        => await Session.Query<ProductEntity>()
            .FirstOrDefaultAsync(x =>
                x.Name == name
                && x.Category.Id == categoryId
                && x.Owner.Id == ownerId, cancellationToken);
    // 1
    public async Task<ProductEntity> FindByUserAndIdAsync(Guid userId, int productId, CancellationToken cancellationToken)
        => await Session.Query<ProductEntity>()
            .FirstOrDefaultAsync(x =>
                x.Id == productId
                && x.Owner.Id == userId, cancellationToken);
}
