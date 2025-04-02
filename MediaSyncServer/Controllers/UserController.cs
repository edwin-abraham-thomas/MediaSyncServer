using MediaSyncServer.DataAccess;
using MediaSyncServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaSyncServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserRepository _userRepository;

        public UserController(ILogger<UserController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostAsync([FromBody] UserCreateRequest request, CancellationToken cancellationToken)
        {
            User weatherForecast = new User
            {
                _id = request._id,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
            };

            await _userRepository.InsertAsync(weatherForecast, cancellationToken);

            return Ok(weatherForecast);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<User>> GetAsync([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var weatherForecast = await _userRepository.GetAsync(userId, cancellationToken);

            return Ok(weatherForecast);
        }

        [HttpPut]
        public async Task<ActionResult<User>> PutAsync([FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
        {
            User weatherForecastUpdate = new User
            {
                _id = request._id,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
            };

            var weatherForecastResponse = await _userRepository.UpdateAsync(weatherForecastUpdate, cancellationToken);

            return Ok(weatherForecastResponse);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult<bool>> DeleteAsync([FromRoute] string userId, CancellationToken cancellationToken)
        {
            var success = await _userRepository.DeleteAsync(userId, cancellationToken);

            return success ? Ok(true) : new StatusCodeResult(500);
        }

    }
}
