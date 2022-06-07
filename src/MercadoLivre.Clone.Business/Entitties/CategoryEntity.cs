namespace MercadoLivre.Clone.Business.Entitties;

public class CategoryEntity : Entity<int>
{
    public virtual string? Name { get; }
    public virtual CategoryEntity? Category { get; }


    [Obsolete("Apenas para uso do ORM")]
    public CategoryEntity()
    {

    }

    public CategoryEntity(string? name, CategoryEntity? category = null)
    {
        Name = name;
        Category = category;
    }

}

public static class Assert
{
    public static void IsTrue(bool value, string message)
    {
        if (value == false)
            throw new InvalidOperationException(message);
    }
}
