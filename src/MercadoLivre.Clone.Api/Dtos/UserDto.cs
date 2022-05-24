using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [MinLength(6, ErrorMessage = "A {0} deve ter no mínimo {1} caracteres")]
        [Compare(nameof(RepeatedPassword), ErrorMessage = "{0} deve ser igual a {1}")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [MinLength(6, ErrorMessage = "A {0} deve ter no mínimo {1} caracteres")]
        public string? RepeatedPassword { get; set; }
    }
}
