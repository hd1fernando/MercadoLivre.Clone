using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Mapper.CustomProfile;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Api.Mapper;

public class EntityToViewModelProfile : Profile
{
    public EntityToViewModelProfile()
    {
        CreateMap<ProductEntity, ProductDetailViewModel>().ConvertUsing<ProductEntityToProductDetailViewModelConverter>();
        CreateMap<ProductReviewEntity, ProductReviewResponse>().ConvertUsing<ProductReviewEntityToProductReviewResponseConverter>();
    }
}
