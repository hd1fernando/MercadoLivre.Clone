using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.Validations;

public class ProductPurchaseCommandValidator : AbstractValidator<ProductPurchaseCommand>
{
    private readonly IProductRepository _productRepository;

    public ProductPurchaseCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        ProductShouldExist();
        QuantityIsGreaterThanZero();
        ProductHasStock();
    }

    private void ProductHasStock()
    {
        RuleFor(x => x)
            .MustAsync(async (command, cancellationToken) =>
            {
                var productId = command.ProductId;
                var quantity = command.Quantity;

                var product = await _productRepository.FindByIdAsync(productId, cancellationToken);

                return product.AvailableQuantity >= quantity;
            }).WithMessage("Quantidade informada não está disponível em estoque");
    }

    private void QuantityIsGreaterThanZero()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("A quantidade de produtos deve ser maior do que {PropertyValue}");
    }

    private void ProductShouldExist()
    {
        RuleFor(x => x.ProductId)
            .MustAsync(async (productId, cancellationToken) =>
            {
                var product = await _productRepository.FindByIdAsync(productId, cancellationToken);
                return product is not null;
            }).WithMessage("O produto informado não existe");
    }
}
