﻿using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace MercadoLivre.Clone.Data.Repository;

public class CategoryRepository : Repository<CategoryEntity, int>, ICategoryRepository
{
    public CategoryRepository(ISession session) : base(session)
    {
    }

    public async Task<bool> CategoryAlreadyExistAsync(string name, int categoryParentId, CancellationToken cancellationToken)
    {
        var result = await Session.Query<CategoryEntity>()
            .Where(x => x.Name == name && x.Parent.Id == categoryParentId)
            ?.FirstOrDefaultAsync(cancellationToken);

        return result is not null;
    }

}
