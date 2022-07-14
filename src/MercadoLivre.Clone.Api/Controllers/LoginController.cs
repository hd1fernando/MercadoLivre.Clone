using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Extensions.Options;
using MercadoLivre.Clone.Api.Indentity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MercadoLivre.Clone.Api.Controllers;

// CI: 6
public class LoginController : MainController
{
    private readonly SignInManager<IdentityUserEntity> _signInManager;
    private readonly UserManager<IdentityUserEntity> _userManager;
    private readonly AppSettings _appSettings;

    // 2
    public LoginController(SignInManager<IdentityUserEntity> signInManager, IOptions<AppSettings> appSettings, UserManager<IdentityUserEntity> userManager)
    {
        _signInManager = signInManager;
        _appSettings = appSettings.Value;
        _userManager = userManager;
    }

    [HttpPost]
    [AllowAnonymous]
    // 1
    public async Task<ActionResult> Login(UserLoginViewModel userLoginViewModel)
    {
        var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.Login, userLoginViewModel.Password, false, true);

        // 1
        if (result.Succeeded)
            return Ok(new
            {
                Token = GenerateJwt(userLoginViewModel.Login)
            });

        // 1
        if (result.IsLockedOut)
            return BadRequest("Muitas tentativas inválidas. Usuário temporariamente bloqueado.");

        return BadRequest("Usuário ou senha inválidos.");
    }

    private async Task<string> GenerateJwt(string email)
    {
        ArgumentNullException.ThrowIfNull(_appSettings.Secret, nameof(_appSettings.Secret));
        ArgumentNullException.ThrowIfNull(_appSettings.Emiter, nameof(_appSettings.Emiter));
        ArgumentNullException.ThrowIfNull(_appSettings.ExpirationTime, nameof(_appSettings.ExpirationTime));

        var user = await _userManager.FindByEmailAsync(email);

        var identityClaims = await AddClaimsAsync(user);


        var tokenHander = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var token = tokenHander.CreateToken(
            new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emiter,
                Audience = _appSettings.ValidIn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

        var encodedToken = tokenHander.WriteToken(token);

        return encodedToken;
    }

    private async Task<ClaimsIdentity> AddClaimsAsync(IdentityUserEntity user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        var userRoles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
        /// 1
        foreach (var userRole in userRoles)
        {
            claims.Add(new Claim("role", userRole));
        }

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        return identityClaims;
    }

    private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
}
