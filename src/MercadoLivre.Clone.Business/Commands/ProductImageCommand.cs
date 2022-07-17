using Microsoft.AspNetCore.Http;

namespace MercadoLivre.Clone.Business.Commands
{
    public class ProductImageCommand : CommandBase
    {
        public int ProductId { get; set; }
        public List<IFormFile>? Images { get; set; }
        public string UploadPath => Path.Combine( @"C:\Images", $"{Guid.NewGuid()}_" );
    }
}
