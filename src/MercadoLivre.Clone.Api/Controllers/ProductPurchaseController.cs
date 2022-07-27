using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;
using MercadoLivre.Clone.Business.Entitties;
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
    public async Task<ActionResult> Payment(ProductPurchaseViewModel productPurchaseViewModel, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<ProductPurchaseCommand>(productPurchaseViewModel);

        var id = await _mediator.Send(command, cancellationToken);

        var url = string.Empty;
        var returnUrl = "";
        if (productPurchaseViewModel.Gateway == PaymentGateway.Paypal)
            url = $"paypal.com/{id}?redirectUrl={returnUrl}";
        else
            url = $"pagseguro.com?returnId={id}&redirectUrl={returnUrl}";

        return Ok(url);
    }

}
