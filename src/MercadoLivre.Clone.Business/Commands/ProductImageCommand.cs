namespace MercadoLivre.Clone.Business.Commands
{
    public class ProductImageCommand : CommandBase
    {
        public int ProductId { get; set; }
        public string? ImageName { get; set; }
    }
}
