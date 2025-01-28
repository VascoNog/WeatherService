namespace WeatherService.App.Models;

public class WeatherStackStructure
{
    public Request Request { get; set; }
    public Location Location { get; set; }
    public Current Current { get; set; }
}

public class Request
{
    public string Type { get; set; }
    public string Query { get; set; }
    public string Language { get; set; }
    public string Unit { get; set; }
}

public class Location
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string TimezoneId { get; set; }
    public DateTime Localtime { get; set; }
    public long LocaltimeEpoch { get; set; }
    public string UtcOffset { get; set; }
}

public class Current
{
    public string ObservationTime { get; set; }
    public int Temperature { get; set; }
    public int WeatherCode { get; set; }
    public List<string> WeatherIcons { get; set; }
    public List<string> WeatherDescriptions { get; set; }
    public int WindSpeed { get; set; }
    public int WindDegree { get; set; }
    public string WindDir { get; set; }
    public int Pressure { get; set; }
    public int Precip { get; set; }
    public int Humidity { get; set; }
    public int CloudCover { get; set; }
    public int FeelsLike { get; set; }
    public int UvIndex { get; set; }
    public int Visibility { get; set; }
    public string IsDay { get; set; }
}
