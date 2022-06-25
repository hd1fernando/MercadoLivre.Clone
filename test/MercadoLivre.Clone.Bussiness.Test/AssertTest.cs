using Bogus;
using FluentAssertions;
using System;
using Xunit;
using EntityAssert = MercadoLivre.Clone.Business.Entitties.Validator.Assert;
namespace MercadoLivre.Clone.Bussiness.Test;

public class AssertTest
{
    string ErrorMessage = new Faker().Lorem.Text();

    [Fact(DisplayName = "Lança exceção quando IsTrue recebe um valor falso")]
    public void IsTrue_Trows_excetption_when_receive_false()
    {
        Action result = () => EntityAssert.IsTrue(false, ErrorMessage);

        result.Should().Throw<InvalidOperationException>().WithMessage(ErrorMessage);
    }

    [Theory(DisplayName = "Lança exceção quando IsNotEmpty recebe string nula ou vazia")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void IsNotEmpty_Trows_excetption_when_receive_null_or_empty(string value)
    {
        Action result = () => EntityAssert.IsNotEmpty(value, ErrorMessage);

        result.Should().Throw<InvalidOperationException>().WithMessage(ErrorMessage);
    }

    [Theory(DisplayName = "Lança exceção quando não é menor do que o minimo informado")]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    public void Minimun_throws_exception_when_length_is_less_than_min(int length, int min)
    {
        Action result = () => EntityAssert.Minimun(length, min, ErrorMessage);

        result.Should().Throw<InvalidOperationException>().WithMessage(ErrorMessage);
    }

    [Theory(DisplayName = "Lança exceção length é maior do que o máximo informado")]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    public void Maximun_throws_exception_when_length_is_greater_than_max(int length, int max)
    {
        Action result = () => EntityAssert.Maximun(length, max, ErrorMessage);

        result.Should().Throw<InvalidOperationException>().WithMessage(ErrorMessage);
    }


}
