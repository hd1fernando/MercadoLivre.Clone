using MercadoLivre.Clone.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductImageController : MainController
{
    [HttpPost]
    public async Task<ActionResult> Update(ProductImageViewModel productImageView)
    {
        var imageName = $"{Guid.NewGuid()}_{productImageView.ImageName}";
        if (UploadFile(productImageView.Image, imageName) == false)
        {
            return BadRequest(ModelState);
        }

        productImageView.ImageName = imageName;


        return Ok();
    }

    private bool UploadFile(string file, string imgName)
    {
        var imageDataByteArray = Convert.FromBase64String(file);

        if (string.IsNullOrEmpty(file))
        {
            ModelState.AddModelError(string.Empty, "Forneca uma image para esse produto.");
            return false;
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgName);

        if (System.IO.File.Exists(filePath))
        {
            ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome.");
            return false;
        }

        System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

        return true;
    }

}
