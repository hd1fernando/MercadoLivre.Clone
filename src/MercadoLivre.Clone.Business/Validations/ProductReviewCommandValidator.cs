using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.Validations;

public class ProductReviewCommandValidator : AbstractValidator<ProductReviewCommand>
{
    private readonly IProductRepository _productRepository;

    public ProductReviewCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RateShulBeInAValidRange();
        TitleIsRequired();
        DescriptionIsRequired();
        DescriptionMaximunCachaters();
        RelatedProductMustExist();
    }

    private void RelatedProductMustExist()
    {
        RuleFor(x => x.ProductId)
            .MustAsync(async (productId, cancellationToken) =>
            {
                var product = await _productRepository.FindByIdAsync(productId, cancellationToken);

                return product is not null;

            }).WithMessage("O Produto que você tentou avalidar não exite");
    }

    private void DescriptionMaximunCachaters()
    {
        RuleFor(x => x.Description?.Length ?? 0)
            .LessThanOrEqualTo(500)
            .WithMessage("A descrição não pode conter mais do que {PropertyValue} caracteres.");
    }

    private void DescriptionIsRequired()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória");
    }

    private void TitleIsRequired()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título é obrigatório");
    }

    private void RateShulBeInAValidRange()
    {
        RuleFor(x => x.Rate)
            .Must(rate => rate >= 1 && rate <= 5)
            .WithMessage("Nota deve ser entre 1 e 5");
    }
}
