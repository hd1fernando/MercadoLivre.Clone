using Microsoft.AspNetCore.Identity;

namespace MercadoLivre.Clone.Api.Indentity.Entities
{
    public class IdentityUserEntity : IdentityUser
    {
        public DateTimeOffset RegistrationTime { get; protected set; }

        [Obsolete("apenas para orm")]
        public IdentityUserEntity()
        {

        }

        public IdentityUserEntity(
            string login,
            string userName,
            DateTimeOffset registrationTime,
            bool emailConfirmed = true)
        {
            if (registrationTime >= DateTimeOffset.UtcNow)
               throw new ArgumentOutOfRangeException(nameof(registrationTime), "a data de registro do usuário não pode estar no futuro.");

            Email = login;
            NormalizedEmail = login.ToUpper();
            UserName = userName;
            NormalizedUserName = userName.ToUpper();
            RegistrationTime = registrationTime;
            EmailConfirmed = emailConfirmed;
        }
    }
}
