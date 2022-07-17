using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductImageEntity : Entity<int>
{
    public virtual string? Path { get; }
    public virtual ProductEntity Product { get; }

    [Obsolete("Apenas para uso do ORM")]
    public ProductImageEntity()
    {

    }

    public ProductImageEntity(string? path, ProductEntity product)
    {
        Assert.IsNotEmpty(path!, $"{nameof(path)} é obrigatório");
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        Path = path;
        Product = product;

    }
}
