using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductQuestionController : MainController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductQuestionController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public Task<ActionResult> Create(ProductQuestionViewModel productQuestionViewModel)
    {

        return Ok();
    }

}
