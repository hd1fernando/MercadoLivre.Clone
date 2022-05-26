using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Indentity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUserEntity> _userManager;

    public UserController(UserManager<IdentityUserEntity> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserViewModel userDto)
    {
        var result = await _userManager.CreateAsync(userDto.ToModel(), userDto.Password);

        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }
}
