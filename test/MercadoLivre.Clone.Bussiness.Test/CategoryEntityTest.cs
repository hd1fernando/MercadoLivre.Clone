using FluentAssertions;
using MercadoLivre.Clone.Business.Entitties;
using System;
using Xunit;
namespace MercadoLivre.Clone.Bussiness.Test
{
    public class CategoryEntityTest
    {
        [Theory(DisplayName = "Deve lançar exception quando o nome da categoria não for informado")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_Throws_exception_when_name_isnt_send(string name)
        {
            Action result = () => new CategoryEntity(name);

            result.Should().Throw<Exception>();
        }
    }
}
