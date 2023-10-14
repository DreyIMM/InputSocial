using IPS.Identidade.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace IPS.Identidade.API.Extensions
{
    public class UsuarioLoginModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true
            };

            var usuario = JsonSerializer.Deserialize<UsuarioRegistro>(bindingContext.ValueProvider.GetValue("UsuarioRegistro").FirstOrDefault(), serializeOptions);
            usuario.fotoPerfil = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

            bindingContext.Result = ModelBindingResult.Success(usuario);
            return Task.CompletedTask;
        }

    }
}
