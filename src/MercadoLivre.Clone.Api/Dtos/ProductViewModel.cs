using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class ProductViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    public string? Name { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "{0} deve ser no mínimo {1}")]
    public decimal Price { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "{0} deve ser no mínimo {1}")]
    public int AvailableQuantity { get; set; }

    [MinLength(3, ErrorMessage = "{0} deve possuir no mínimo {1} {0}")]
    public List<string> Features { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]
    [MaxLength(1000, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
    public string? Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} é obrigatória")]
    public int CategoryId { get; set; }
}
