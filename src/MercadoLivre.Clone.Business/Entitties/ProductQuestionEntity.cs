using MercadoLivre.Clone.Business.Entitties.Validator;

namespace MercadoLivre.Clone.Business.Entitties;

public class ProductQuestionEntity : Entity<int>
{
    public virtual string? Title { get; }
    public virtual DateTimeOffset QuestionDate { get; }
    public virtual UserEntity User { get;  }
    public virtual ProductEntity Product { get; }

    [Obsolete("Apenas para uso do ORM")]
    public ProductQuestionEntity()
    {

    }

    public ProductQuestionEntity(string? title, UserEntity user, ProductEntity product)
    {
        Assert.IsNotEmpty(title!, $"{nameof(title)} deve conter um valor");
        ArgumentNullException.ThrowIfNull(user, nameof(user));
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        Title = title;
        QuestionDate = DateTimeOffset.Now;
        User = user;
        Product = product;
    }

}
