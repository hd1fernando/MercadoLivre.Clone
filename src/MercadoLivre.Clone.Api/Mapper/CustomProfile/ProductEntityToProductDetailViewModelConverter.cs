using AutoMapper;
using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Business.Entitties;
using MercadoLivre.Clone.Business.Repository;

namespace MercadoLivre.Clone.Api.Mapper.CustomProfile
{
    // CI: 10
    // 2
    public class ProductEntityToProductDetailViewModelConverter : ITypeConverter<ProductEntity, ProductDetailViewModel>
    {
        // 3
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductQuestionRepository _productQuestionRepository;
        private readonly IProductReivewRepository _productReivewRepository;
        private readonly IMapper _mapper;

        public ProductEntityToProductDetailViewModelConverter(
            IProductImageRepository productImageRepository,
            IProductQuestionRepository productQuestionRepository,
            IProductReivewRepository productReivewRepository,
            IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _productQuestionRepository = productQuestionRepository;
            _productReivewRepository = productReivewRepository;
            _mapper = mapper;
        }

        public ProductDetailViewModel Convert(ProductEntity source, ProductDetailViewModel destination, ResolutionContext context)
        {
            // 1
            var productImage = _productImageRepository.FindByProductId(source.Id)?
                .Select(p => p.Path!)?
                .ToList() ?? new List<string> { "" };

            // 2
            var productQuestions = _productQuestionRepository.FindByProductId(source.Id)?
                .OrderBy(p => p.QuestionDate)?
                .Select(p => p.Title!)?
                .ToList() ?? new List<string> { "" };

            var productReviews = _productReivewRepository.FindByProductId(source.Id);

            // 2
            var averageRate = productReviews?.Average(x => x?.Rate) ?? 0.0;
            var rateQuantity = productReviews?.Sum(_ => 1) ?? 0;

            var reviews = new List<ProductReviewResponse>();
            // 1
            foreach (var productReview in productReviews!)
                reviews.Add(_mapper.Map<ProductReviewResponse>(productReview));

            var productDetailViewModel = new ProductDetailViewModel
            {
                Name = source.Name!,
                RateQuantity = rateQuantity,
                AverageRate = averageRate,
                Description = source.Description!,
                Features = source.Features?.Split(',').ToList() ?? new List<string> { "" },
                LinkImages = productImage,
                Price = source.Price,
                Questions = productQuestions,
                Reviews = reviews
            };


            return productDetailViewModel;
        }
    }
}
