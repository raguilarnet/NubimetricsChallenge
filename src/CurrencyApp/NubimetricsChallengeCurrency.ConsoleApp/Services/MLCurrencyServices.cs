using NubimetricsChallengeCurrency.ConsoleApp.Interfaces;
using NubimetricsChallengeCurrency.ConsoleApp.Models;
using System.Text.Json;

namespace NubimetricsChallengeCurrency.ConsoleApp.Services;

public class MLCurrencyServices : IMLCurrencyServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MLCurrencyServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Currency>> GetAllCurrencies()
    {
        List<Currency> result = new List<Currency>();

        HttpClient httpClient = _httpClientFactory.CreateClient("MLCurrencyClientAPI");

        try
        {
            using (var response = await httpClient.GetAsync("", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var streamResult = await response.Content.ReadAsStreamAsync();

                var currencyInfo = await JsonSerializer.DeserializeAsync<List<Currency>>(streamResult);

                if (currencyInfo is not null)
                {
                    return currencyInfo;
                }
            }
            return result;
        }
        catch (Exception)
        {
            return result;
        }
    }
}
