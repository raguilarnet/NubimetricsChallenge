using NubimetricsChallenge.Application.DTOs;

namespace NubimetricsChallenge.Application.Interfaces.Services;

public interface ISearchesService
{
    Task<ItemBasicInfoDTO> GetItemInfo(string item);
}
