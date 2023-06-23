using Microsoft.AspNetCore.Mvc;
using Redis.Sample.Models;
using Redis.Sample.Services;
using StackExchange.Redis.Profiling;
using System.Text.Json;

namespace Redis.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _profileService.Get(Id.ToString());
            return Ok(JsonSerializer.Deserialize<Profile>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] Profile profile)
        {
            await _profileService.Set(profile.Id.ToString(), JsonSerializer.Serialize(profile));
            return StatusCode(StatusCodes.Status201Created, profile.Id);
        }
    }
}
