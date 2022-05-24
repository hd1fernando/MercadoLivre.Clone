using MercadoLivre.Clone.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create(UserDto userDto)
    {

        return Ok();
    }
}
