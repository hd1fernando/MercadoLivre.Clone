using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.Validations;
public class CategoryCommandValidator : AbstractValidator<CategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;


    public CategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        CategoryNameIsRequired();
        CategoryNameIsUnique();
        _categoryRepository = categoryRepository;
    }

    private void CategoryNameIsUnique()
    {
        RuleFor(c => c.Name)
            .MustAsync(async (name, cancellationToken) =>
            {
                var exist = await _categoryRepository.CategoryAlreadyExistAsync(name ?? string.Empty, cancellationToken);
                return exist == false;
            }).WithMessage("A categoria informada já existe.");
    }

    private void CategoryNameIsRequired()
    {
        RuleFor(c => c.Name)
           .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
           .NotNull().WithMessage("O nome da categoria é obrigatório.");
    }
}
