using FluentValidation;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Repository;
using MercadoLivre.Clone.Business.Users;

namespace MercadoLivre.Clone.Business.Validations;

public class ProductImageCommandValidator : AbstractValidator<ProductImageCommand>
{
    private readonly IUser _user;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public ProductImageCommandValidator(IUser user, IProductRepository productRepository, IUserRepository userRepository)
    {
        _user = user;
        _productRepository = productRepository;

        ImageMustExist();
        FileNameShouldBeUnique();
        ProductIsFromDeLoggedUser();

        _userRepository = userRepository;
    }

    private void FileNameShouldBeUnique()
    {
        RuleFor(x => x)
            .Must(command =>
            {
                foreach (var image in command.Images)
                {
                    var path = command.UploadPath + image.FileName;
                    if (System.IO.File.Exists(path))
                        return false;
                }

                return true;

            }).WithMessage("Já existe um arquivo com esse nome");
    }

    private void ImageMustExist()
    {
        RuleFor(x => x.Images)
            .Must(images =>
            {
                foreach (var image in images)
                {
                    if (image is null || image.Length == 0)
                        return false;
                }

                return true;
            }).WithMessage("Forneça uma imagem para esse producto");
    }

    private void ProductIsFromDeLoggedUser()
    {
        RuleFor(x => x.ProductId)
            .MustAsync(async (productId, cancellationToken) =>
            {
                var owner = await _userRepository.FindByUserEmailAsync(_user.GetUserEmail(), cancellationToken);
                var product = await _productRepository.FindByUserAndIdAsync(owner.Id, productId, cancellationToken);

                return product is not null;
            }).WithMessage("Você está tentando cadastrar imagem para um produto inexistente");
    }
}
