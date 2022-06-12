using FluentAssertions;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Validations;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace MercadoLivre.Clone.Bussiness.Test;

public class CategoryCommandValidatorTest
{
    ICategoryRepository _categoryRepository = Substitute.For<ICategoryRepository>();

    [Theory(DisplayName = "Categoria não é válida quando o nome não foi informado")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task CategoryNameIsRequired_return_false_when_name_isEmpty(string name)
    {
        var validator = new CategoryCommandValidator(_categoryRepository);
        var command = new CategoryCommand { Name = name };

        var result = await MakeValidatorResultAsync(validator, command);

        result.Should().BeFalse();
    }

    private async Task<bool> MakeValidatorResultAsync(CategoryCommandValidator validator, CategoryCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        return validationResult.IsValid;
    }
}

