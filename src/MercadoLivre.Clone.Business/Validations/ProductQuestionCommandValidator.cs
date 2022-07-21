using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.Validations;

public class ProductQuestionCommandValidator : AbstractValidator<ProductQuestionCommand>
{
    private readonly IProductRepository _productRepository;

    public ProductQuestionCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        TitleIsRequired();
        ProductIsRequired();
    }

    private void ProductIsRequired()
    {
        RuleFor(x => x.Productid)
            .MustAsync(async (productId, cancellationToken) =>
            {
                var product = await _productRepository.FindByIdAsync(productId, cancellationToken);

                return product is not null;

            }).WithMessage("O produto informado não existe");
    }

    private void TitleIsRequired()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("A pergunta não pode estar em branco");
    }
}
