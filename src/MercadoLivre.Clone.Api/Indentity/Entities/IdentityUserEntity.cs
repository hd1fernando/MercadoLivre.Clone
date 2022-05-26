using Microsoft.AspNetCore.Identity;

namespace MercadoLivre.Clone.Api.Indentity.Entities
{
    public class IdentityUserEntity : IdentityUser
    {
        public DateTimeOffset RegistrationTime { get; set; }
    }
}
