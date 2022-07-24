using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDetailController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductDetailController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<ProductDetailViewModel>> GetProduct(int productId, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository.FindByIdAsync(productId, cancellationToken);

        if (productEntity is null)
            return BadRequest("Produto inexistente");

        var productDetail = _mapper.Map<ProductDetailViewModel>(productEntity) ?? throw new NullReferenceException();

        return Ok(productDetail);
    }
}
