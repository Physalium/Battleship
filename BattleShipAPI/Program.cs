using System.Reflection;
using BattleShipAPI.Endpoints;
using BattleShipAPI.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
   var frontendURL = builder.Configuration.GetValue<string>("frontend_url");
   options.AddPolicy("BattleshipPolicy",
      builder => { builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader(); });
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
   c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
   {
      Type = SecuritySchemeType.ApiKey,
      In = ParameterLocation.Header,
      Name = "ApiKey",
      Description = "API key"
   });
   c.AddSecurityRequirement(new OpenApiSecurityRequirement
   {
      {
         new OpenApiSecurityScheme
         {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
         },
         new string[] { }
      }
   });
});

builder.Services.AddFluentValidation(fv =>
{
   fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
   fv.ValidatorOptions.LanguageManager.Enabled = false;
});

builder.Services.AddGameServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseCors("BattleshipPolicy");

app.UseHttpsRedirection();
app.UseMiddleware<ApiKeyValidationMiddleware>();

// Endpoints
app.MapGameEndpoints();

app.Run();

public partial class Program
{
}