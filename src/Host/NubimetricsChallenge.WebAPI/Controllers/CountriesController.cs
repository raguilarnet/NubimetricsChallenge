using Microsoft.AspNetCore.Mvc;
using NubimetricsChallenge.Application.Interfaces.Services;

namespace NubimetricsChallenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        public ICountriesService _countriesService { get; set; }

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        // GET api/<CountriesController>/AR
        [HttpGet("{country}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string country)
        {
            try
            {
                switch (country.ToUpper())
                {
                    case "AR":
                        var result = await _countriesService.GetCountryInfo(country.ToUpper());
                        return Ok(result);
                    case "BR":
                        return Unauthorized();
                    case "CO":
                        return Unauthorized();
                    default:
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
