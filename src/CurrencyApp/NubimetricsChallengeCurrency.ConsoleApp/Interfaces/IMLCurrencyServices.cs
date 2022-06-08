using NubimetricsChallengeCurrency.ConsoleApp.Models;

namespace NubimetricsChallengeCurrency.ConsoleApp.Interfaces;

public interface IMLCurrencyServices
{
    Task<List<Currency>> GetAllCurrencies();
}
