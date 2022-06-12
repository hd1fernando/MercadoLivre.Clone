using FluentAssertions;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
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
        var validator = BuildCategoryCommandValidator();
        var command = new CategoryCommand { Name = name };

        var result = await MakeValidatorResultAsync(validator, command);

        result.Should().BeFalse();
    }


    [Fact(DisplayName = "Retorna falso quando já existe uma categoria cadastrada")]
    public async Task CategoryNameIsUnique_returnsFalse_when_category_already_exist()
    {
        var validator = BuildCategoryCommandValidator();
        var command = new CategoryCommand { Name = CategoryFixture.GenerateName() };

        _categoryRepository
            .CategoryAlreadyExistAsync(command.Name, command.CategoryId, default)
            .Returns(true);

        var result = await MakeValidatorResultAsync(validator, command);

        result.Should().BeFalse();
    }

    [Fact(DisplayName = "Retorna true quando não existe uma categoria cadastrada")]
    public async Task CategoryNameIsUnique_returTrue_when_category_not_exist()
    {
        var validator = BuildCategoryCommandValidator();
        var command = new CategoryCommand { Name = CategoryFixture.GenerateName() };

        _categoryRepository
            .CategoryAlreadyExistAsync(command.Name, command.CategoryId, default)
            .Returns(false);


        var result = await MakeValidatorResultAsync(validator, command);

        result.Should().BeTrue();
    }

    [Theory(DisplayName = "Retorna true quando id da categoria pai não foi informado")]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CategoryParentMustExist_returnFalse_when_CategoryId_isNot_informed(int categoryParentId)
    {
        var validator = BuildCategoryCommandValidator();
        var command = new CategoryCommand { Name = CategoryFixture.GenerateName(), CategoryId = categoryParentId };

        _categoryRepository
            .FindByIdAsync(command.CategoryId, default)
            .Returns((CategoryEntity)null);

        _categoryRepository
            .CategoryAlreadyExistAsync(command.Name, command.CategoryId, default)
            .Returns(false);

        var result = await MakeValidatorResultAsync(validator, command);

        result.Should().BeTrue();
    }



    private async Task<bool> MakeValidatorResultAsync(CategoryCommandValidator validator, CategoryCommand command)
    {
        var validationResult = await validator.ValidateAsync(command);
        return validationResult.IsValid;
    }

    private CategoryCommandValidator BuildCategoryCommandValidator()
        => new CategoryCommandValidator(_categoryRepository);
}

