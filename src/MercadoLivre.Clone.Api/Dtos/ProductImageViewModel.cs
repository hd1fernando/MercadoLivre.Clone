using MercadoLivre.Clone.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

// CI 1
// 1
[ModelBinder(BinderType = typeof(JsonModelBinder))]
public class ProductImageViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} deve ter um valor válido")]
    public int ProductId { get; set; }

    public List<IFormFile>? Images { get; } = new List<IFormFile>();

    public void AddImages(IList<IFormFile> images)
    {
        // 1
        ArgumentNullException.ThrowIfNull(images, nameof(images));
        if (images.Any() == false)
            throw new ArgumentException("A adição de imagens deve conter imagens");

        Images.AddRange(images);
    }
}
