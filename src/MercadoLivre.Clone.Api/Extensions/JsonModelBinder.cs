using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace MercadoLivre.Clone.Api.Extensions;

// CI: 2
public class JsonModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext, nameof(bindingContext));

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult != ValueProviderResult.None)
        {
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

            var valueAsString = valueProviderResult.FirstValue ?? throw new NullReferenceException("first name retornou null");

            var result = JsonSerializer.Deserialize(valueAsString, bindingContext.ModelType);
            if (result is not null)
            {
                bindingContext.Result = ModelBindingResult.Success(result);
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }
}
