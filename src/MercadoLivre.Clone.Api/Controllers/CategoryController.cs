using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
    {
        var command = _mapper.Map<CategoryCommand>(categoryViewModel);

        await _mediator.Send(command);

        return Ok();
    }
}
