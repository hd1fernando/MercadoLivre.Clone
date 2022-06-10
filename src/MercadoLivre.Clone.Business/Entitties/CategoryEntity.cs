namespace MercadoLivre.Clone.Business.Entitties;

public class CategoryEntity : Entity<int>
{
    public virtual string? Name { get; }
    public virtual CategoryEntity? Parent { get; protected set; }


    [Obsolete("Apenas para uso do ORM")]
    public CategoryEntity()
    {

    }

    public CategoryEntity(string? name)
    {
        Assert.IsTrue(!string.IsNullOrEmpty(name), $"{nameof(name)} é obrigatório.");
        Name = name;
    }

    public virtual void AddParent(CategoryEntity parent)
    {
        ArgumentNullException.ThrowIfNull(parent, nameof(parent));
        Parent = parent;
    }

}
