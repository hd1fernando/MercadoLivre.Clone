using Bogus;
using MercadoLivre.Clone.Business.CommandHandlers;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using NSubstitute;
using Xunit;

namespace MercadoLivre.Clone.Bussiness.Test
{

    public class CreateCategoryTest
    {
        ICategoryRepository CategoryRepository = Substitute.For<ICategoryRepository>();
        IUnitOfWork Uow = Substitute.For<IUnitOfWork>();

        [Theory(DisplayName = "Não adiciona uma categoria pai quando CategoryId é menor ou igual a zero")]
        [InlineData(0)]
        [InlineData(-1)]
        public async void Handler_Dont_Add_CategoryParent_when_CategoryId_is_default(int categoryId)
        {
            var command = new CategoryCommand { Name = GenerateName(), CategoryId = categoryId };
            var handler = BuildCommandHander();

            var result = await handler.Handle(command, default);

            await CategoryRepository
                    .DidNotReceiveWithAnyArgs()
                    .FindByIdAsync(command.CategoryId, default);

            await CategoryRepository
                    .Received()
                    .AddAsync(Arg.Any<CategoryEntity>(), default);

            await Uow.Received()
                .Commit(default);
        }

        [Theory(DisplayName = "Adiciona uma categoria pai quando CategoryId é maior do que zero")]
        [InlineData(1)]
        [InlineData(2)]
        public async void Handler_Add_CategoryParent_when_CategoryParent_is_greater_than_zero(int categoryId)
        {
            var command = new CategoryCommand { Name = GenerateName(), CategoryId = categoryId };
            var handler = BuildCommandHander();

            var result = await handler.Handle(command, default);

            await CategoryRepository
                    .Received()
                    .FindByIdAsync(command.CategoryId, default);

            await CategoryRepository
                    .Received()
                    .AddAsync(Arg.Any<CategoryEntity>(), default);

            await Uow.Received()
                .Commit(default);
        }

        private string GenerateName()
         => new Faker("pt_BR").Name.ToString();

        private CategoryCommandHandler BuildCommandHander()
             => new CategoryCommandHandler(CategoryRepository, Uow);

    }
}
