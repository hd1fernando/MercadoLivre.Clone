using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class ProductReviewViewModel
{
    [Range(1, 5, ErrorMessage = "{0} deve estar entre {1} e {2}.")]
    public int Rate { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório.")]
    [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} carateres.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [MaxLength(500, ErrorMessage = "{0} deve ter no máximo {1} carateres.")]
    public string? Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} é obrigatório")]
    public int ProductId { get; set; }


}
