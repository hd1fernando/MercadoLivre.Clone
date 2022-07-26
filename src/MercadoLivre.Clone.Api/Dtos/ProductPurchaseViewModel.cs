using MercadoLivre.Clone.Business.Entitties;
using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class ProductPurchaseViewModel
{
    [Range(1, int.MaxValue, ErrorMessage = "{0} é obrigatório.")]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "pelo menos {1} {0} é obrigatório.")]
    public int Quantity { get; set; }

    public PaymentGateway Gateway { get; set; }
}
