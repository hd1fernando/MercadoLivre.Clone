namespace MercadoLivre.Clone.Business.Entitties;

public class UserEntity : Entity<Guid>
{
    public virtual string? UserName { get; protected set; }
    public virtual string? UserEmail { get; protected set; }

}
