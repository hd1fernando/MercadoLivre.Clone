namespace MercadoLivre.Clone.Business.Entitties;

public class CategoryEntity : Entity<int>
{
    public virtual string? Name { get; }

    [Obsolete("Apenas para uso do ORM")]
    public CategoryEntity()
    {

    }

    public CategoryEntity(string? name)
    {
        Name = name;
    }

    public CategoryEntity(string? name, int categoryId)
    {
        Name = name;
        Id = categoryId;
    }
}
