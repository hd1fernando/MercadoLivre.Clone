using MercadoLivre.Clone.Business.Users;
using System.Security.Claims;

namespace MercadoLivre.Clone.Api.Extensions;

public class AspNetUser : IUser
{
    private readonly IHttpContextAccessor _acessor;

    public AspNetUser(IHttpContextAccessor acessor)
    {
        _acessor = acessor;
    }

    private ClaimsPrincipal User => _acessor.HttpContext.User;

    public string Name => User.Identity.Name ?? throw new InvalidOperationException("HttpContex sem UserName");

    public IEnumerable<Claim> GetClaimsIdentity()
        => User.Claims;

    public string GetUserEmail()
        => IsAuthenticated() ? User.GetUserEmail() : string.Empty;

    public Guid GetUserId()
        => IsAuthenticated() ? Guid.Parse((User.GetUserId())) : Guid.Empty;

    public bool IsAuthenticated()
        => User.Identity.IsAuthenticated;

    public bool IsInRole(string roleName)
        => User.IsInRole(roleName);
}

public static class ClaimsPrincipalExtensions
{
    public static string GetUserEmail(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal, nameof(principal));

        var claim = principal.FindFirst(ClaimTypes.Email);
        return claim?.Value;
    }

    public static string GetUserId(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal, nameof(principal));

        var claim = principal.FindFirst(ClaimTypes.GivenName);
        return claim?.Value;
    }
}
