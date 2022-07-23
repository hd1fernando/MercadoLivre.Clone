using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductQuestionController : MainController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductQuestionController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductQuestionViewModel productQuestionViewModel,CancellationToken cancellationToken)
    {
        var command = _mapper.Map<ProductQuestionCommand>(productQuestionViewModel);

        await _mediator.Send(command, cancellationToken);

        return Ok();
    }

}
