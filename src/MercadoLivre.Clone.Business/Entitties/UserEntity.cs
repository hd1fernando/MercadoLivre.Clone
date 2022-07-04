namespace MercadoLivre.Clone.Business.Entitties;

public class UserEntity : Entity<Guid>
{
    public virtual string? UserName { get; protected set; }
    public virtual string? Email { get; protected set; }

    public UserEntity(string? userName, string? email)
    {
        UserName = userName;
        Email = email;
    }

    [Obsolete("Apenas para uso do ORM")]
    public UserEntity()
    {
    }

}
