using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.Application.Interfaces.Services;
using System.Text.Json;

namespace NubimetricsChallenge.Application.Services;

public class CountriesService : ICountriesService
{
    private IHttpClientFactory _httpClientFactory;

    public CountriesService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<CountryInfoDTO> GetCountryInfo(string country)
    {
        CountryInfoDTO result = new CountryInfoDTO();

        HttpClient httpClient = _httpClientFactory.CreateClient("MercadoLibreClient");

        try
        {
            using (var response = await httpClient.GetAsync($"classified_locations/countries/{country}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var streamResult = await response.Content.ReadAsStreamAsync();

                var countryInfo = await JsonSerializer.DeserializeAsync<CountryInfoDTO>(streamResult);

                if (countryInfo is not null)
                {
                    return countryInfo;
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
