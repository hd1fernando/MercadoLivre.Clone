using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductPurchaseController : MainController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductPurchaseController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Payment(ProductPurchaseViewModel productPurchaseViewModel)
    {
        var command = _mapper.Map<ProductPurchaseCommand>(productPurchaseViewModel);

        var id = await _mediator.Send(command);

        var url = $"https://mercadolivre/{productPurchaseViewModel.Gateway}/{id}";
        return Ok(url); 
    }

}
