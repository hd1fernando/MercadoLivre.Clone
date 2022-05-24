using Microsoft.AspNetCore.Identity;

namespace MercadoLivre.Clone.Api.Indentity.Entities
{
    public class UserEntity : IdentityUser
    {
        public DateTimeOffset Instant { get; set; }
    }
}
