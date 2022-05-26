using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Indentity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

// CI: 3
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // 1
    private readonly UserManager<IdentityUserEntity> _userManager;

    public UserController(UserManager<IdentityUserEntity> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    // 1
    public async Task<ActionResult> Create(UserViewModel userViewModel)
    {
        var result = await _userManager.CreateAsync(userViewModel.ToModel(), userViewModel.Password);

        // 1
        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);
    }
}
