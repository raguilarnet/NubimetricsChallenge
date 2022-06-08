using NubimetricsChallenge.Application.DTOs;

namespace NubimetricsChallenge.Application.Interfaces.Services;

public interface ICountriesService
{
    Task<CountryInfoDTO> GetCountryInfo(string country);
}
