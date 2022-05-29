using System.ComponentModel.DataAnnotations;

namespace MercadoLivre.Clone.Api.Dtos;

public class CategoryViewModel
{
    public string? Name { get; set; }

    public int CategoryId { get; set; }
}
