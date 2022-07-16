using MercadoLivre.Clone.Api.Dtos;
using MercadoLivre.Clone.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MercadoLivre.Clone.Api.Controllers;

public class ProductImageController : MainController
{
    [RequestSizeLimit(50000000)]
    [HttpPost]
    public async Task<ActionResult> Update([ModelBinder(typeof(JsonModelBinder))] ProductImageViewModel ProductImageViewModel, IList<IFormFile> files)
    {

        if (files.Any() == false)
        {
            ModelState.AddModelError(string.Empty, "Forneça uma imagem para esse produto");
            return BadRequest(ModelState);
        }

        foreach (var file in files)
        {
            var prefix = $"{Guid.NewGuid()}_";
            string imagePath = "wwwroot/app/demo-webapi/src/assests";
            var path = Path.Combine(Directory.GetCurrentDirectory(), imagePath, prefix + file.FileName);

            if (CanUploadFile(file, path) == false)
                return BadRequest(ModelState);

            await UploadIFormFileAsync(file, path);
        }

        return Ok();
    }


    private bool CanUploadFile(IFormFile file, string path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(path, $"{nameof(path)} deve conter um valor");

        if (file is null || file.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Forneça uma imagem para esse produto");
            return false;
        }

        if (System.IO.File.Exists(path))
        {
            ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome");
            return false;
        }

        return true;
    }

    private async Task UploadIFormFileAsync(IFormFile file, string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
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
