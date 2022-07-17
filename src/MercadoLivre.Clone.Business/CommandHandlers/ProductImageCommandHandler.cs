using MediatR;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Options;
using MercadoLivre.Clone.Business.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MercadoLivre.Clone.Business.CommandHandlers;

// CI 5
public class ProductImageCommandHandler : IRequestHandler<ProductImageCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IRepository<ProductImageEntity, int> _productImageRepository;
    private readonly Images _images;


    // 4
    public ProductImageCommandHandler(
        IProductRepository productRepository,
        IRepository<ProductImageEntity, int> productImageRepository,
        IOptions<Images> images)
    {

        _productRepository = productRepository;
        _productImageRepository = productImageRepository;
        _images = images.Value;

        if (string.IsNullOrEmpty(_images.UploadPath))
            throw new Exception("Caminho de upload de imagem deve existir");
    }

    // 1
    public async Task<Unit> Handle(ProductImageCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FindByIdAsync(request.ProductId, cancellationToken);

        // 1
        foreach (var image in request.Images)
        {
            var prefix = $"{Guid.NewGuid()}_";
            var path = _images.UploadPath + prefix + image.FileName;

            // 1
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
