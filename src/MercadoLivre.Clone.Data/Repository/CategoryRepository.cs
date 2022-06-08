using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate.Linq;
using System.Data;

namespace MercadoLivre.Clone.Data.Repository;

public class CategoryRepository : Repository<CategoryEntity, int>, ICategoryRepository
{
    public CategoryRepository(NHibernateContext context) : base(context)
    {
    }

    ~CategoryRepository()
        => Context.Dispose();

    public async Task<bool> CategoryAlreadyExistAsync(string name, CancellationToken cancellationToken)
    {
        Context.BeginTransaction();

        var result = await Context.Session.Query<CategoryEntity>()
            .Where(x => x.Name == name)
            ?.FirstOrDefaultAsync(cancellationToken);

        return result is not null;
    }

}
