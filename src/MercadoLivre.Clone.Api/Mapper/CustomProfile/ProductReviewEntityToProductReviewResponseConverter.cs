using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Api.Mapper.CustomProfile
{
    public class ProductReviewEntityToProductReviewResponseConverter : ITypeConverter<ProductReviewEntity, ProductReviewResponse>
    {
        public ProductReviewResponse Convert(ProductReviewEntity source, ProductReviewResponse destination, ResolutionContext context)
            => new ProductReviewResponse
            {
                Description = source.Description,
                Title = source.Title
            };
    }
}
