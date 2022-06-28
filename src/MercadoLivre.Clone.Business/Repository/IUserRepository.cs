using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface IUserRepository : IRepository<UserEntity, Guid>
{
    public Task<UserEntity> FindByUserEmailAsync(string userEmail, CancellationToken cancellationToken);
}
