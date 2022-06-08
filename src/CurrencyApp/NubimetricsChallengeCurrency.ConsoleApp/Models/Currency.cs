namespace NubimetricsChallengeCurrency.ConsoleApp.Models;

public class Currency
{
    public string id { get; set; } = String.Empty;
    public string symbol { get; set; } = String.Empty;
    public string description { get; set; } = String.Empty;
    public int decimal_places { get; set; }
}
