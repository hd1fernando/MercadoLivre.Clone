using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.Validations;

// CI: 3
public class ProductCommandValidator : AbstractValidator<ProductCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    // 1
    public ProductCommandValidator(ICategoryRepository categoryRepository)
    {

        _categoryRepository = categoryRepository;

        NameIsRequired();
        PriceIsGreateThanZero();
        AvailableQuantityIsGreaterThanOrEqualZero();
        AtLeastTreeFeatures();
        DescriptionWithMaxOf1000Characters();
        CategoryIsRequired();
    }

    private void AvailableQuantityIsGreaterThanOrEqualZero()
    {
        RuleFor(x => x.AvailableQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("A quantidade deve ser maior ou igual a {PropertyValue}.");
    }

    private void CategoryIsRequired()
    {
        // 2
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("A categoria é obrigatória.")
            .MustAsync(async (id, cancelationToken) =>
            {
                var category = await _categoryRepository.FindByIdAsync(id, cancelationToken);
                return category is not null;
            }).WithMessage("O id para categoria informado não existe para esse produto.");
    }

    private void DescriptionWithMaxOf1000Characters()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição do produto é obrigatória")
            .MaximumLength(1000).WithMessage("A descrição de um produto não pode ter mais do que {PropertyValue} caracteres");
    }

    private void AtLeastTreeFeatures()
    {
        RuleFor(x => x.Features)
            .MinimumLength(3).WithMessage("O produto deve ter no mínimo {PropertyValue} características.");
    }

    private void PriceIsGreateThanZero()
    {
        RuleFor(c => c.Price)
            .GreaterThan(0).WithMessage("O valor da categoria deve ser maior do que {PropertyValue}.");
    }

    private void NameIsRequired()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("O nome da categoria é obrigatório.");
    }
}
