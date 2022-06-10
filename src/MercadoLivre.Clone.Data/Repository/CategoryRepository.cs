using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;
using System.Data;
using System.Linq.Expressions;

namespace MercadoLivre.Clone.Data.Repository;

public class CategoryRepository : Repository<CategoryEntity, int>, ICategoryRepository
{
    public CategoryRepository(ISession session) : base(session)
    {
    }

    public async Task<bool> CategoryAlreadyExistAsync(string name, int categoryParentId, CancellationToken cancellationToken)
    {
        Expression<Func<CategoryEntity, bool>> predicate = categoryParentId == default
             ? x => x.Name == name
             : x => x.Name == name && x.Parent.Id == categoryParentId;

        var result = await Session.Query<CategoryEntity>()
            .Where(predicate)
            ?.FirstOrDefaultAsync(cancellationToken);

        return result is not null;
    }

}
