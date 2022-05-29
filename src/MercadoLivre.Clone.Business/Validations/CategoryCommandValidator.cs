using FluentValidation;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Business.Validations;
public class CategoryCommandValidator : AbstractValidator<CategoryCommand>
{
    public CategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
            .NotNull().WithMessage("O nome da categoria é obrigatório.");
    }
}
