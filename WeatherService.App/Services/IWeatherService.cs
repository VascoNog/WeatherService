using RestSharp;
using System.Text.Json;

namespace WeatherService.App.Services;

public interface IWeatherService
{
    Weather GetWeather(string region);
}

public class WeatherStackService : IWeatherService
{
    private readonly string _baseUrl = "";
    private readonly string _apiKey = "";
    private readonly HttpClient _httpClient;

    public WeatherStackService(HttpClient httpClient, IConfiguration configuration)
    {
        _baseUrl = configuration.GetValue<string>("WeatherStack:BaseUrl");
        _apiKey = configuration.GetValue<string>("WeatherStack:ApiKey");
        _httpClient = httpClient;
    }

    public Weather GetWeather(string region)
    {
        string endpoint = $"{_baseUrl}/current?access_key={_apiKey}&query={region ?? "New York"}";
        Console.WriteLine("Endpoint: " + endpoint);
        var client = new RestClient(endpoint);
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        var current = JsonSerializer.Deserialize<WeatherStackStructure>(response.Content, options);

        return new Weather
        {
            Lat = current.Location.Lat,
            Lon = current.Location.Lon,
            Country = current.Location.Country,
            Region = current.Location.Region,
            Temperature = current.Current.Temperature,
            UpdatedAt = current.Location.Localtime,
            Icon = current.Current.WeatherIcons.FirstOrDefault() ?? string.Empty,
        };
    }
}