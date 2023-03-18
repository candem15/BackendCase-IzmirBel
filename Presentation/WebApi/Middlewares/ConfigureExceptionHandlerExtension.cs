using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    //Uygulama hali hazırda tek tip exception handle ettiği için exception tür kontrolü gerçekleştirmedim.
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Title = "An error occurred!",
                            Message = contextFeature.Error.Message
                        }));
                    }
                });
            });
        }
    }
}
