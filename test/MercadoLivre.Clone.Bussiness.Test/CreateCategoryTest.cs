using Bogus;
using MediatR;
using MercadoLivre.Clone.Business.CommandHandlers;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MercadoLivre.Clone.Bussiness.Test
{
    public class CreateCategoryTest
    {
        [Fact(DisplayName = "Não adiciona uma categoria pai quando CategoryId é 0 ou default")]
        public async void Handler_Dont_Add_CategoryParent_when_CategoryId_is_default()
        {
            var categoryRepository = Substitute.For<ICategoryRepository>();
            var uow = Substitute.For<IUnitOfWork>();

            var fakeName = new Faker("pt_BR").Name.ToString();

            var command = new CategoryCommand { Name = fakeName, CategoryId = 0 };
            var handler = new CategoryCommandHandler(categoryRepository, uow);

            var result = await handler.Handle(command, default);

            await categoryRepository
                    .DidNotReceiveWithAnyArgs()
                    .FindByIdAsync(command.CategoryId, default);

            await categoryRepository
                    .Received()
                    .AddAsync(Arg.Any<CategoryEntity>(), default);

            await uow.Received()
                .Commit(default);
        }

        [Theory(DisplayName = "Adiciona uma categoria pai quando CategoryId é maior do que zero")]
        [InlineData(1)]
        [InlineData(2)]
        public async void Handler_Add_CategoryParent_when_Cate(int categoryId)
        {
            var categoryRepository = Substitute.For<ICategoryRepository>();
            var uow = Substitute.For<IUnitOfWork>();

            var fakeName = new Faker("pt_BR").Name.ToString();

            var command = new CategoryCommand { Name = fakeName, CategoryId = categoryId };
            var handler = new CategoryCommandHandler(categoryRepository, uow);

            var result = await handler.Handle(command, default);

            await categoryRepository
                    .Received()
                    .FindByIdAsync(command.CategoryId, default);

            await categoryRepository
                    .Received()
                    .AddAsync(Arg.Any<CategoryEntity>(), default);

            await uow.Received()
                .Commit(default);
        }
    }
}
