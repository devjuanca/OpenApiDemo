namespace DemoOpenApiNet9.Dto;

public record WeatherForecast(string City, DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

/// <summary>
///  Create a new weather forecast
/// </summary>
/// <param name="City"></param>
/// <param name="Date"></param>
/// <param name="TemperatureC"></param>
/// <param name="Summary"></param>
public record CreateWeatherForecastCommand(string City, DateTime Date, int TemperatureC, string? Summary);

public static class WeatherForecastMapper
{
    public static WeatherForecast Map(this CreateWeatherForecastCommand addWeatherForeCast)
    {
        var (city, date, temp, summary) = addWeatherForeCast;

        return new WeatherForecast(city, DateOnly.FromDateTime(date), temp, summary);
    }
}