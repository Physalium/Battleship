using Microsoft.Extensions.Primitives;

namespace BattleShipAPI.Middleware;

public class ApiKeyValidationMiddleware
{
   private const string APIKEYNAME = "ApiKey";
   private readonly RequestDelegate _next;

   public ApiKeyValidationMiddleware(RequestDelegate next)
   {
      _next = next;
   }

   public async Task InvokeAsync(HttpContext context)
   {
      if (!context.Request.Headers.TryGetValue(APIKEYNAME, out StringValues extractedApiKey))
      {
         context.Response.StatusCode = 401;
         await context.Response.WriteAsync("API key was not provided.");
         return;
      }

      var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

      var apiKey = appSettings.GetValue<string>(APIKEYNAME);

      if (!apiKey.Equals(extractedApiKey))
      {
         context.Response.StatusCode = 401;
         await context.Response.WriteAsync("Unauthorized access.");
         return;
      }

      await _next(context);
   }
}