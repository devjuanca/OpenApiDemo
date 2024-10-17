using DemoApiNet9.Dto;
using DemoApiNet9.Services;

namespace DemoApiNet9.V1;

public static partial class CityWeatherEndpoints
{
    public static WebApplication MapCitiesVersionOneWeatherEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/weather-api/v1/cities")
                       .WithTags("Cities Weather Endpoints")
                       .WithGroupName("v1");

        group.MapGet("/weatherforecast", (WeatherService service) =>
        {
            return service.GetWeatherForecasts();

        }).Produces<List<WeatherForecast>>()
          .WithDescription("Gets weather forcasts for all cities")
          .RequireAuthorization();


        group.MapGet("/forecast/{city}", (string city, WeatherService service) =>
        {
            var forecast = service.GetWeatherForecast(city);

            if (forecast != null)
            {
                return Results.Ok(forecast);
            }
            return Results.NotFound();

        }).Produces<WeatherForecast>()
          .Produces(404)
          .WithDescription("Gets a city weather forcast")
          .RequireAuthorization();

        group.MapPost("/forecast", (CreateWeatherForecastCommand newforecast, WeatherService service) =>
        {
            service.AddWeatherForecast(newforecast.Map());

            return Results.Created();

        }).Produces(201)
          .WithDescription("Creates a city weather forecast");

        group.MapDelete("/forecast", (string city, WeatherService service) =>
        {
            service.DeleteForcast(city);

            return Results.NoContent();

        }).Produces(204)
          .WithDescription("Deletes a weather forcast")
          .RequireAuthorization();

        return app;
    }
}