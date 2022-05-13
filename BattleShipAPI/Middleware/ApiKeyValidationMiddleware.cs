namespace BattleShipAPI.Middleware;

public class ApiKeyValidationMiddleware
{
    private readonly RequestDelegate _next;
    private const string APIKEYNAME = "ApiKey";
    public ApiKeyValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(APIKEYNAME, out Microsoft.Extensions.Primitives.StringValues extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API key was not provided.");
            return;
        }

        IConfiguration? appSettings = context.RequestServices.GetRequiredService<IConfiguration>();

        string? apiKey = appSettings.GetValue<string>(APIKEYNAME);

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized access.");
            return;
        }

        await _next(context);
    }
}