using DemoApiNet9.Dto;

namespace DemoApiNet9.Services;

public class WeatherRepository
{
    private readonly List<WeatherForecast> WeatherForecasts = [];

    public WeatherRepository()
    {
        string[] cities = ["London", "Paris", "Rome"];

        string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

        WeatherForecasts = Enumerable.Range(0, 3).Select(index =>
               new WeatherForecast
               (
                   City: cities[index],
                   DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                   Random.Shared.Next(-20, 55),
                   summaries[Random.Shared.Next(summaries.Length)]
               )).ToList();
    }

    public void Add(WeatherForecast weatherForecast)
    {
        WeatherForecasts.Add(weatherForecast);
    }

    public void Delete(string city)
    {
        var forcast = GetWeatherForecastByCity(city);

        if (forcast is not null)
        {
            WeatherForecasts.Remove(forcast);
        }
    }

    public List<WeatherForecast> GetWeatherForecasts()
    {
        return WeatherForecasts;
    }

    public WeatherForecast? GetWeatherForecastByCity(string cityName)
    {
        return WeatherForecasts.Find(a => a.City == cityName);
    }
}
