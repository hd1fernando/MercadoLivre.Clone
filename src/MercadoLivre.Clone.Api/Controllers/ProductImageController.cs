using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Extensions;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductImageController : MainController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ProductImageController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [RequestSizeLimit(50000000)]
    [HttpPost]
    public async Task<ActionResult> Update([ModelBinder(typeof(JsonModelBinder))] ProductImageViewModel productImageViewModel, IList<IFormFile> files)
    {

        if (files.Any() == false)
        {
            ModelState.AddModelError(string.Empty, "Forneça uma imagem para esse produto");
            return BadRequest(ModelState);
        }

        productImageViewModel.AddImages(files);
        var productImageCommand = _mapper.Map<ProductImageCommand>(productImageViewModel);
        await _mediator.Send(productImageCommand);

        return Ok();
    }
}
