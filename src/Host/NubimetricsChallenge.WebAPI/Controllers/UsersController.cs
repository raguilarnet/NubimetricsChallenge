using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.Application.Interfaces.Services;
using NubimetricsChallenge.WebAPI.Models;

namespace NubimetricsChallenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        public IUsersServices _usersService { get; set; }

        public UsersController(IUsersServices usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUser = await _usersService.GetAllUsersAsync();
                if (allUser.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allUser);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Invalid id");
                }
                var foundUser = await _usersService.GetUserByIdAsync(id);
                if (foundUser is null)
                {
                    return NotFound();
                }
                return Ok(foundUser);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] UserModel userToInsert)
        {
            try
            {
                if (userToInsert is null)
                {
                    return BadRequest("UserToInsert object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var createdUser = await _usersService.InsertAsync(_mapper.Map<UserDTO>(userToInsert));

                return CreatedAtAction("Get", new { id = createdUser.Id}, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] UserModel userToUpdate)
        {
            try
            {
                if (userToUpdate is null)
                {
                    return BadRequest("UserToUpdate object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var userEntity = _mapper.Map<UserDTO>(userToUpdate);

                var isUpdated = await _usersService.UpdateAsync(id, userEntity);

                if (!isUpdated)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Invalid id");
                }
                var isDeleted = await _usersService.DeleteAsync(id);

                if (!isDeleted)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
