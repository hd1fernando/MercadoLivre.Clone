using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Extensions;
using MercadoLivre.Clone.Api.Indentity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MercadoLivre.Clone.Api.Controllers;

// CI: 5
public class LoginController : MainController
{
    private readonly SignInManager<IdentityUserEntity> _signInManager;
    private readonly AppSettings _appSettings;

    // 2
    public LoginController(SignInManager<IdentityUserEntity> signInManager, IOptions<AppSettings> appSettings)
    {
        _signInManager = signInManager;
        _appSettings = appSettings.Value;
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
                Token = GenerateJwt()
            });

        // 1
        if (result.IsLockedOut)
            return BadRequest("Muitas tentativas inválidas. Usuário temporariamente bloqueado.");

        return BadRequest("Usuário ou senha inválidos.");
    }

    private string GenerateJwt()
    {
        ArgumentNullException.ThrowIfNull(_appSettings.Secret, nameof(_appSettings.Secret));
        ArgumentNullException.ThrowIfNull(_appSettings.Emiter, nameof(_appSettings.Emiter));
        ArgumentNullException.ThrowIfNull(_appSettings.ExpirationTime, nameof(_appSettings.ExpirationTime));


        var tokenHander = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var token = tokenHander.CreateToken(
            new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emiter,
                Audience = _appSettings.ValidIn,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

        var encodedToken = tokenHander.WriteToken(token);

        return encodedToken;
    }

}
