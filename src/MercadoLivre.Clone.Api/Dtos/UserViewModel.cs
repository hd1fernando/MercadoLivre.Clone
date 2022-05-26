using MercadoLivre.Clone.Api.Indentity.Entities;
using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "{0} deve ser um e-mail válid.")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [MinLength(6, ErrorMessage = "A {0} deve ter no mínimo {1} caracteres.")]
        [Compare(nameof(RepeatedPassword), ErrorMessage = "{0} deve ser igual a {1}.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [MinLength(6, ErrorMessage = "A {0} deve ter no mínimo {1} caracteres.")]
        public string? RepeatedPassword { get; set; }

        public IdentityUserEntity ToModel()
            => new IdentityUserEntity
            {
                Email = Login,
                NormalizedEmail = Login.ToUpper(),
                UserName = Login,
                NormalizedUserName = Login.ToUpper(),
                RegistrationTime = DateTimeOffset.UtcNow,
                EmailConfirmed = true,
            };
    }
}
