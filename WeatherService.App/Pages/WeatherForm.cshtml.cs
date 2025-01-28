using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherService.App.Models;

namespace WeatherService.App.Pages;

public class WeatherFormModel : PageModel
{
    public Weather MyWeather { get; set; }

    private readonly IWeatherService _weatherService;
    public string Message { get; set; }

    [BindProperty]
    public string City { get; set; }

    public WeatherFormModel(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        MyWeather = _weatherService.GetWeather(City);
    }
}
