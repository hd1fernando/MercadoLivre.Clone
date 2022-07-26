using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public enum PaymentGateway
{
    Paypal,
    PagSeguro
}

public class ProductEntity : Entity<int>
{
    public virtual string? Name { get; protected set; }
    public virtual decimal Price { get; protected set; }
    public virtual int AvailableQuantity { get; protected set; }
    public virtual string? Features { get; protected set; }
    public virtual string? Description { get; protected set; }
    public virtual CategoryEntity Category { get; protected set; }
    public virtual UserEntity Owner { get; protected set; }
    public virtual DateTimeOffset Instant { get; protected set; }

    [Obsolete("Apenas para uso do ORM.")]
    public ProductEntity()
    {

    }

    public ProductEntity(string? name, decimal price, int availableQuantity, List<string?> features, string? description, CategoryEntity category, UserEntity owner)
    {
        Assert.IsNotEmpty(name!, $"{nameof(name)} é obrigatório.");
        Assert.IsTrue(price > 0, $"{nameof(price)} deve ser maior do que zero.");
        Assert.IsTrue(availableQuantity >= 0, $"{nameof(availableQuantity)} deve ser maior ou igual a zero.");
        Assert.IsTrue(features.Count() >= 3, $"{nameof(availableQuantity)} deve ter pelo menos três itens");
        Assert.IsTrue(string.IsNullOrEmpty(description) == false, $"{nameof(description)} é obrigatória");
        Assert.Maximun(description?.Length ?? 0, 1000, $"{nameof(description)} deve ter no máximo 1000 caracteres");
        ArgumentNullException.ThrowIfNull(category, nameof(category));
        ArgumentNullException.ThrowIfNull(owner, nameof(owner));

        Name = name;
        Price = price;
        AvailableQuantity = availableQuantity;
        Features = string.Join(',', features.ToHashSet());
        Description = description;
        Category = category;
        Instant = DateTimeOffset.Now;
        Owner = owner;
    }

    public virtual void SlaughterStock(int quantity)
    {
        Assert.RangeInclusive(quantity, 0, AvailableQuantity, $"Tentativa de abater estoque inválida.");
        AvailableQuantity -= quantity;
    }
}
