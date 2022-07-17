using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductReviewController : MainController
{
    private readonly IMapper _mapper;
    private readonly IMediator _meditor;


    public ProductReviewController(IMapper mapper, IMediator meditor)
    {
        _mapper = mapper;
        _meditor = meditor;
    }

    [HttpPost]
    public async Task<ActionResult> Review(ProductReviewViewModel productReviewViewModel, CancellationToken cancellationToken)
    {
        var productReviewCommand = _mapper.Map<ProductReviewCommand>(productReviewViewModel);
        await _meditor.Send(productReviewCommand, cancellationToken);
        return Ok();
    }
}
