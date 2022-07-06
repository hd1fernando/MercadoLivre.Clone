using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;

namespace MercadoLivre.Clone.Business.Validations;

// CI: 6
public class ProductCommandValidator : AbstractValidator<ProductCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUser _user;

    // 4
    public ProductCommandValidator(
        ICategoryRepository categoryRepository,
        IUserRepository userRepository,
        IProductRepository productRepository,
        IUser user)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;


        NameIsRequired();
        PriceIsGreateThanZero();
        AvailableQuantityIsGreaterThanOrEqualZero();
        AtLeastTreeFeatures();
        NonDuplicateFeatures();
        DescriptionWithMaxOf1000Characters();
        CategoryIsRequired();
        CategoryOwnerIsRequired();
        ProductIsUnique();
        _productRepository = productRepository;
        _user = user;
    }

    private void ProductIsUnique()
    {
        RuleFor(x => x)
            .MustAsync(async (product, cancellationToken) =>
            {
                var owner = await _userRepository.FindByUserEmailAsync(_user.GetUserEmail(), cancellationToken);
                var productEntity = await _productRepository.FindBydNameAndCategoryAsync(product?.Name, product.CategoryId, owner.Id, cancellationToken);

                return productEntity is null;
            }).WithMessage("O produto já está cadastrado");

    }

    private void CategoryOwnerIsRequired()
    {

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
            .NotEmpty().WithMessage("Não é possível cadastrar produto sem característica")
            .Must(x => x.Count() >= 3)
            .WithMessage("O produto deve conter no mínimo 3 características");
    }

    private void NonDuplicateFeatures()
    {
        RuleFor(x => x.Features)
            .Must((features) =>
            {
                var hashSetSize = features?.ToHashSet().Count();

                return hashSetSize == features?.Count();
            }).WithMessage("Existe características repetidas no produto");
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
