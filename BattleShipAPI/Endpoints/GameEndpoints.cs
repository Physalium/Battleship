﻿using BattleShipAPI.Models;
using BattleShipAPI.Services;
using BattleShipCore.Models.History;
using FluentValidation;
using FluentValidation.Results;

namespace BattleShipAPI.Endpoints;

public static class GameEndpoints
{
   public static void MapGameEndpoints(this WebApplication app)
   {
      app.MapGet("/generate", GenerateGame).Produces<GameHistory>();
   }

   public static void AddGameServices(this IServiceCollection services)
   {
      services.AddScoped<IGameGenerationService, GameGenerationService>();
   }

   private static async Task<IResult> GenerateGame(IGameGenerationService service, IValidator<GenerateGameRequest> validator,
      string? firstPlayerName = "Player 1", string? secondPlayerName = "Player 2")
   {
      var request = new GenerateGameRequest(firstPlayerName, secondPlayerName);
      ValidationResult? validationResult = validator.Validate(request);
      if (!validationResult.IsValid)
      {
         List<string> errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
         return Results.BadRequest(errors);
      }

      try
      {
         GameHistory? response = service.GenerateGameAndReturnHistory(request);
         return Results.Ok(response);
      }
      catch (Exception ex)
      {
         return Results.Problem(ex.Message);
      }
   }
}