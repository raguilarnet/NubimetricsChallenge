using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.Application.Interfaces.Services;
using System.Text.Json;

namespace NubimetricsChallenge.Application.Services;

public class SearchesService : ISearchesService
{
    private IHttpClientFactory _httpClientFactory;

    public SearchesService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ItemBasicInfoDTO> GetItemInfo(string item)
    {
        ItemBasicInfoDTO result = new ItemBasicInfoDTO();

        HttpClient httpClient = _httpClientFactory.CreateClient("MercadoLibreClient");

        try
        {
            using (var response = await httpClient.GetAsync($"sites/MLA/search?q={item}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var streamResult = await response.Content.ReadAsStreamAsync();

                var itemInfo = await JsonSerializer.DeserializeAsync<ItemBasicInfoDTO>(streamResult);

                if (itemInfo is not null)
                {
                    return itemInfo;
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            return result;
        }
    }
}
