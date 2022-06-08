using NubimetricsChallengeCurrency.ConsoleApp.Interfaces;
using NubimetricsChallengeCurrency.ConsoleApp.Models;
using System.Text.Json;

namespace NubimetricsChallengeCurrency.ConsoleApp.Services;

public class MLCurrencyConversionsServices : IMLCurrencyConversionsServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MLCurrencyConversionsServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<CurrencyConversions> GetCurrencyConversionById(string currencyId)
    {
        CurrencyConversions result = new CurrencyConversions();

        HttpClient httpClient = _httpClientFactory.CreateClient("MLCurrencyConversionsClientAPI");

        try
        {
            using (var response = await httpClient.GetAsync($"search?from={currencyId.ToUpper()}&to=USD", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var streamResult = await response.Content.ReadAsStreamAsync();

                var currencyConversionsInfo = await JsonSerializer.DeserializeAsync<CurrencyConversions>(streamResult);

                if (currencyConversionsInfo is not null)
                {
                    return currencyConversionsInfo;
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
