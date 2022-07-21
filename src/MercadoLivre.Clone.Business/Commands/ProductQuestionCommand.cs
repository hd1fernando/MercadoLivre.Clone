namespace MercadoLivre.Clone.Business.Commands
{
    public class ProductQuestionCommand : CommandBase
    {
        public string? Title { get; set; }

        public int Productid { get; set; }
    }
}
