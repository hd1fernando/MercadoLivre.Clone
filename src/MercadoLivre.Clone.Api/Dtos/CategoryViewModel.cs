using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class CategoryViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório")]
    public string? Name { get; set; }

    public int CategoryId { get; set; }
}
