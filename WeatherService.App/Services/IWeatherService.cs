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
        Console.WriteLine(region);
        string endpoint = $"{_baseUrl}/current?access_key={_apiKey}&query={region ?? "New York"}";
        Console.WriteLine("Endpoint: " + endpoint);
        var client = new RestClient(endpoint);
        var request = new RestRequest("", Method.Get);
        var response = client.Execute(request);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            //NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
        };

        var current = JsonSerializer.Deserialize<WeatherStackStructure>(response.Content, options);

        return new Weather
        {
            Lat = GetValidCoordinate(current?.Location?.Lat) ?? 0.0d,
            Lon = GetValidCoordinate(current?.Location?.Lon) ?? 0.0d,
            Country = current?.Location?.Country ?? "Country Not Available",
            Region = current?.Location?.Name ?? "City Not Available",
            Temperature = current?.Current?.Temperature ?? 0.0d,
            UpdatedAt = GetValidDateTime(current?.Location?.Localtime),
            Icon = current?.Current?.WeatherIcons?.FirstOrDefault() ?? string.Empty,
        };

    }

    public double? GetValidCoordinate(string coordinate)
    {
        if (string.IsNullOrEmpty(coordinate))
            return null;

        return double.TryParse(coordinate.Replace(".", ","), out double result) ? result : null;
    }


    // A segunda linha do Json options nao funcionou e continuei com o Replace
    // Ver o que se passa

    public DateTime GetValidDateTime(string stringDate)
        => DateTime.TryParse(stringDate, out DateTime result) ? result : DateTime.Today;
}