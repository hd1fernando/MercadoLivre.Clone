namespace MercadoLivre.Clone.Api.Dtos;

public class ProductDetailViewModel
{
    public string? Name { get; set; }
    public List<string>? LinkImages { get; set; }
    public decimal Price { get; set; }
    public List<string>? Features { get; set; }
    public string? Description { get; set; }
    public double AverageRate { get; set; }
    public int RateQuantity { get; set; }
    public List<ProductReviewResponse>? Reviews { get; set; }
    public List<string>? Questions { get; set; }
}

public class ProductReviewResponse
{
    public string? Title { get; set; }
    public string? Description { get; set; }
}
