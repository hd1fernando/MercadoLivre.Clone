using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductQuestionEntity : Entity<int>
{
    public string? Title { get; }
    public DateTimeOffset QuestionDate { get; }
    public UserEntity User { get; }
    public ProductEntity Product { get; }

    public ProductQuestionEntity(string? title, UserEntity user, ProductEntity product)
    {
        Assert.IsNotEmpty(title, $"{nameof(title)} deve conter um valor");
        ArgumentNullException.ThrowIfNull(user, nameof(user);
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        Title = title;
        QuestionDate = DateTimeOffset.Now;
        User = user;
        Product = product;
    }

}
