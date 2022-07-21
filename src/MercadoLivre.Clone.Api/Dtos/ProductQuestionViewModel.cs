using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class ProductQuestionViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório.")]
    public string? Title { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "{0} inválido.")]
    public int Productid { get; set; }
}
