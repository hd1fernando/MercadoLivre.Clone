namespace MercadoLivre.Clone.Business.Entitties;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    public virtual TId Id { get; protected set; }

    public virtual bool Equals(Entity<TId>? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Id is not null && Id.Equals(other.Id))
            return true;

        return false;
    }
}

