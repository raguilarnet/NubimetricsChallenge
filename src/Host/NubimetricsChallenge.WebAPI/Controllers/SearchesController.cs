using Microsoft.AspNetCore.Mvc;
using NubimetricsChallenge.Application.Interfaces.Services;

namespace NubimetricsChallenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
        public ISearchesService _searchesService { get; set; }

        public SearchesController(ISearchesService searchesService)
        {
            _searchesService = searchesService;
        }

        // GET api/<SearchesController>/iphone
        [HttpGet("{item}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string item)
        {
            try
            {
                var result = await _searchesService.GetItemInfo(item);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }
    }
}
