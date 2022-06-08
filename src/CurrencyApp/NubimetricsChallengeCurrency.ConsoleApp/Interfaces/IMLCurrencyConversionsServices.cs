using NubimetricsChallengeCurrency.ConsoleApp.Models;

namespace NubimetricsChallengeCurrency.ConsoleApp.Interfaces;

public interface IMLCurrencyConversionsServices
{
    Task<CurrencyConversions> GetCurrencyConversionById(string currencyId);
}
