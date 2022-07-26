namespace MercadoLivre.Clone.Business.Commands
{
    public class ProductCommand : CommandBase
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public List<string>? Features { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}
