namespace MercadoLivre.Clone.Business.Commands
{
    public class ProductReviewCommand : CommandBase
    {
        public int Rate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
    }
}
