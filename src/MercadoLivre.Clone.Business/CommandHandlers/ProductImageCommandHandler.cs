using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;
using Microsoft.AspNetCore.Http;

namespace MercadoLivre.Clone.Business.CommandHandlers;

public class ProductImageCommandHandler : IRequestHandler<ProductImageCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IRepository<ProductImageEntity, int> _productImageRepository;

    public ProductImageCommandHandler(IProductRepository productRepository, IRepository<ProductImageEntity, int> productImageRepository)
    {
        _productRepository = productRepository;
        _productImageRepository = productImageRepository;
    }

    public async Task<Unit> Handle(ProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);

        foreach (var image in request.Images)
        {
            var path = request.UploadPath + image.FileName;

            var productImage = new ProductImageEntity(path, product);

            await _productImageRepository.AddAsync(productImage, cancellationToken);


            await UploadIFormFileAsync(image, path);
        }

        return Unit.Value;
    }

    private async Task UploadIFormFileAsync(IFormFile file, string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
    }

}
