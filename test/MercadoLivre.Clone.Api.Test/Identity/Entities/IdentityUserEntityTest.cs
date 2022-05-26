using Bogus;
using FluentAssertions;
using MercadoLivre.Clone.Api.Indentity.Entities;
using System;
using Xunit;

namespace MercadoLivre.Clone.Api.Test.Identity.Entities
{
    public class IdentityUserEntityTest
    {
        [Fact(DisplayName = "Data do cadastro não pode ser no futuro.")]
        public void Test1()
        {
            var login = new Faker().Person.Email;
            var date = DateTimeOffset.Now.AddSeconds(1);

            Action result = () => new IdentityUserEntity(login, login, date);

            result.Should().Throw<InvalidOperationException>(because: "data de cadastro não pode ser no futuro.");
        }

        [Theory(DisplayName = "Login de usuário deve ser um email válido")]
        [InlineData("teste@teste.com.")]
        [InlineData("testeteste.com")]
        [InlineData("")]
        [InlineData(null)]
        public void Test2(string login)
        {
            var date = DateTimeOffset.Now;
            var userName = new Faker().Person.Email;


            Action result = () => new IdentityUserEntity(login, userName, date);

            result.Should().Throw<InvalidOperationException>(because: "login deve ser um email válido");
        }

        [Theory(DisplayName = "Nome do usuário deve ser um email válido")]
        [InlineData("teste@teste.com.")]
        [InlineData("testeteste.com")]
        [InlineData("")]
        [InlineData(null)]
        public void Test3(string userName)
        {
            var date = DateTimeOffset.Now;
            var login = new Faker().Person.Email;


            Action result = () => new IdentityUserEntity(login, userName, date);

            result.Should().Throw<InvalidOperationException>(because: "nome de usuário deve ser um email válido");
        }
    }
}
