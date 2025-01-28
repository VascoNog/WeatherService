namespace WeatherService.App.Pages;

public class WeatherModel : PageModel
{
    public Weather MyWeather { get; set; }
    private readonly IWeatherService _weatherService;
    public WeatherModel(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public void OnGet(string city)
    {
        MyWeather = _weatherService.GetWeather(city);
    }
}