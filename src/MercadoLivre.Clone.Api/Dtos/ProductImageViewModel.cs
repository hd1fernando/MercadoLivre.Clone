using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class ProductImageViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} deve ter um valor válido")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório.")]
    public string? ImageName { get; set; }

    public string? Image { get; set; }
}
