namespace NubimetricsChallenge.Application.DTOs;

public class CountryInfoDTO
{
    public string id { get; set; } = default!;
    public string name { get; set; } = default!;
    public string locale { get; set; } = default!;
    public string currency_id { get; set; } = default!;
    public string decimal_separator { get; set; } = default!;
    public string thousands_separator { get; set; } = default!;
    public string time_zone { get; set; } = default!;
    public GeoInformation geo_information { get; set; }
    public List<State> states { get; set; }
}

public class GeoInformation
{
    public Location location { get; set; }
}

public class Location
{
    public double latitude { get; set; }
    public double longitude { get; set; }
}

public class State
{
    public string id { get; set; } = default!;
    public string name { get; set; } = default!;
}
