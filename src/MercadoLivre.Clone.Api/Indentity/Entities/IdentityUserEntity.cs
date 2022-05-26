using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace MercadoLivre.Clone.Api.Indentity.Entities;

// CI: 2
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
        // 1
        Assert.IsTrue(IsValidEmail(login), $"{nameof(login)} deve ser um email válido");
        Assert.IsTrue(IsValidEmail(userName), $"{nameof(userName)} deve ser um email válido");
        Assert.IsTrue(registrationTime <= DateTimeOffset.UtcNow, $" {nameof(registrationTime)} não pode estar no futuro.");

        Email = login;
        NormalizedEmail = login.ToUpper();
        UserName = userName;
        NormalizedUserName = userName.ToUpper();
        RegistrationTime = registrationTime;
        EmailConfirmed = emailConfirmed;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            email = email.Trim();
            // 1
            if (email.EndsWith("."))
                return false;

            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
