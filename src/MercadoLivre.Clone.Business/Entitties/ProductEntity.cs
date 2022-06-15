using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductEntity : Entity<int>
{
    public string? Name { get; }
    public decimal Price { get; }
    public int AvailableQuantity { get; }
    public string? Features { get; }
    public string? Description { get; }
    public CategoryEntity? Category { get; }
    public DateTimeOffset Instant { get; }

    public ProductEntity(string? name, decimal price, int availableQuantity, string? features, string? description, CategoryEntity? category)
    {
        Assert.IsNotEmpty(name!, $"{nameof(name)} é obrigatório.");
        Assert.IsTrue(price > 0, $"{nameof(price)} deve ser maior do que zero.");


        Name = name;
        Price = price;
        AvailableQuantity = availableQuantity;
        Features = features;
        Description = description;
        Category = category;
        Instant = DateTimeOffset.Now;
    }
}
