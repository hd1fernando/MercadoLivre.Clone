using AutoMapper;
using MediatR;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Extensions;
using MercadoLivre.Clone.Business.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

//CI: 3
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
    // 2
    public async Task<ActionResult> Update([ModelBinder(typeof(JsonModelBinder))] ProductImageViewModel productImageViewModel, IList<IFormFile> files)
    {
        // 1
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
