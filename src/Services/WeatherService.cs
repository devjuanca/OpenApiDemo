using DemoApiNet9.Dto;

namespace DemoApiNet9.Services;

public class WeatherService(WeatherRepository weatherRepository)
{

    public List<WeatherForecast> GetWeatherForecasts()
    {
        return weatherRepository.GetWeatherForecasts();
    }

    public WeatherForecast? GetWeatherForecast(string city)
    {
        return weatherRepository.GetWeatherForecastByCity(city);
    }

    public void AddWeatherForecast(WeatherForecast weatherForecast)
    {
        weatherRepository.Add(weatherForecast);
    }

    public void DeleteForcast(string city)
    {
        weatherRepository.Delete(city);
    }
}

