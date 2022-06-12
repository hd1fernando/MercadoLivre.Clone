using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class MainController : ControllerBase
{

}
