using MercadoLivre.Clone.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

//[ModelBinder(BinderType = typeof(JsonModelBinder))]
public class ProductImageViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} deve ter um valor válido")]
    public int ProductId { get; set; }

    //[Required(ErrorMessage = "{0} é obrigatório.")]
    //public string? ImageName { get; set; }

    //public IFormFile? Images { get; set; }
}
