using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class CategoryController : MainController
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CategoryCommand>(categoryViewModel);

        await _mediator.Send(command, cancellationToken);

        return Ok();
    }
}
