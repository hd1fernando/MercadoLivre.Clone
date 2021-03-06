using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NHibernate;
using NHibernate.Linq;

namespace MercadoLivre.Clone.Data.Repository;

// CI: 2
public class UserRepository : Repository<UserEntity, Guid>, IUserRepository
{
    public UserRepository(ISession session) : base(session)
    {
    }
    
    public async Task<UserEntity> FindByUserEmailAsync(string userEmail, CancellationToken cancellationToken)
        => await Session.Query<UserEntity>().FirstOrDefaultAsync(u => u.Email == userEmail, cancellationToken);
}
