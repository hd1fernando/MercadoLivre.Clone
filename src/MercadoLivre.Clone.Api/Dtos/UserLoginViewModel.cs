using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class UserLoginViewModel
{
    [Required(ErrorMessage = "{0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "{0} deve ser um e-mail válido.")]
    public string? Login { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório.")]
    public string? Password { get; set; }
}
