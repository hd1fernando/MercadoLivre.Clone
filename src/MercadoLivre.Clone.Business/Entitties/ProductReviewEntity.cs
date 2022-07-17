using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductReviewEntity : Entity<int>
{
    public int Rate { get; }
    public string? Title { get; }
    public string? Description { get; }
    public ProductEntity Product { get; }
    public UserEntity? User { get; }

    public ProductReviewEntity(int rate, string? title, string? description, ProductEntity product, UserEntity? user)
    {
        Assert.RangeInclusive(rate, 1, 5, $"{nameof(rate)} deve estar entre 1 e 5");
        Assert.IsNotEmpty(title!, $"{nameof(title)} é obrigatório.");
        Assert.IsNotEmpty(description!, $"{nameof(description)} é obrigatório.");
        Assert.Maximun(description?.Length ?? 0, 500, $"{nameof(description)} não pode conter mais do que 500 caracteres.");
        ArgumentNullException.ThrowIfNull(product, nameof(product));
        ArgumentNullException.ThrowIfNull(user, nameof(user));


        Rate = rate;
        Title = title;
        Description = description;
        Product = product;
        User = user;
    }



}
