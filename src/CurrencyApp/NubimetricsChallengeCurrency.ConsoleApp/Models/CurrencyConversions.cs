namespace NubimetricsChallengeCurrency.ConsoleApp.Models;

public class CurrencyConversions
{
    public string currency_base { get; set; } = String.Empty;
    public string currency_quote { get; set; } = String.Empty;
    public double ratio { get; set; }
    public double rate { get; set; }
    public double inv_rate { get; set; }
    public DateTime creation_date { get; set; }
    public DateTime valid_until { get; set; }
}
