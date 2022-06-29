using System.Security.Claims;

namespace MercadoLivre.Clone.Business.Users;
public interface IUser
{
    public string Name { get; }
    public Guid GetUserId();
    public string GetUserEmail();
    bool IsAuthenticated();
    bool IsInRole(string roleName);
    IEnumerable<Claim> GetClaimsIdentity();
}
