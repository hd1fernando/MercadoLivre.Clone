using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Business.Validations;

// CI: 5
// 1
public class CategoryCommandValidator : AbstractValidator<CategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    // 1
    public CategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        CategoryNameIsRequired();
        CategoryNameIsUnique();
        CategoryParentMustExist();

    }

    private void CategoryParentMustExist()
    {
        // 1
        RuleFor(c => c.CategoryId)
            .MustAsync(async (id, cancellationToken) =>
            {
                /// 1
                if (id <= 0)
                    return true;

                var category = await _categoryRepository.FindByIdAsync(id, cancellationToken);

                return category is not null;
            }).WithMessage("A categoria pai informada não existe.");
    }

    private void CategoryNameIsUnique()
    {
        // 1
        RuleFor(categoryCommand => categoryCommand)
            .MustAsync(async (categoryCommand, cancellationToken) =>
            {
                var exist = await _categoryRepository.CategoryAlreadyExistAsync(categoryCommand.Name!, categoryCommand.CategoryId, cancellationToken);
                return exist == false;
            }).WithMessage("A categoria informada já existe.");
    }

    private void CategoryNameIsRequired()
    {
        RuleFor(c => c.Name)
           .NotEmpty().WithMessage("O nome da categoria é obrigatório.");
    }
}
