using MercadoLivre.Clone.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
    {

        return Ok();
    }
}
