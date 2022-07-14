using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductImageController : MainController
{
    //[RequestSizeLimit(50000000)]
    [HttpPost]
    public async Task<ActionResult> Update([ModelBinder(typeof(JsonModelBinder))] ProductImageViewModel productImageView, IList<IFormFile> files)
    {


        return Ok();

        //var prefix = $"{Guid.NewGuid()}_";
        //if (await UploadIFormFileAsync(productImageView.Images, prefix) == false)
        //{
        //    return BadRequest(ModelState);
        //}

        //productImageView.ImageName = prefix + productImageView.Images?.FileName ?? string.Empty;

        //return Ok($"mercadolivre.clone/imagens/{productImageView.ImageName}");
    }

    private async Task<bool> UploadIFormFileAsync(IFormFile file, string prefix)
    {
        if (file is null || file.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Forneça uma imagem para esse produto");
            return false;
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assests", prefix + file.FileName);

        if (System.IO.File.Exists(path))
        {
            ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome");
            return false;
        }

        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        return true;
    }

    private bool UploadBase64File(string file, string imgName)
    {
        var imageDataByteArray = Convert.FromBase64String(file);

        if (string.IsNullOrEmpty(file))
        {
            ModelState.AddModelError(string.Empty, "Forneca uma imagem para esse produto.");
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
