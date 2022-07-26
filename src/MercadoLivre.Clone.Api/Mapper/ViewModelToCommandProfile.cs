using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Commands;

namespace MercadoLivre.Clone.Api.Mapper;

public class ViewModelToCommandProfile : Profile
{
    public ViewModelToCommandProfile()
    {
        CreateMap<CategoryViewModel, CategoryCommand>();
        CreateMap<ProductViewModel, ProductCommand>();
        CreateMap<ProductImageViewModel, ProductImageCommand>();
        CreateMap<ProductReviewViewModel, ProductReviewCommand>();
        CreateMap<ProductQuestionViewModel, ProductQuestionCommand>();
        CreateMap<ProductPurchaseViewModel, ProductPurchaseCommand>();
    }
}
