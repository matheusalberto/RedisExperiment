using Microsoft.AspNetCore.Mvc;
using RedisExperiment.Requests;
using RedisExperiment.Services;
using System.Threading.Tasks;

namespace RedisExperiment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet, Route("{key}")]
        public async Task<IActionResult> GetCachedValue(
            [FromRoute] string key
        )
        {
            var value = await _cacheService.GetCacheValueAsync(key);

            if (string.IsNullOrEmpty(value))
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> SetCacheValue(
            [FromBody] CacheValueRequest request
        )
        {
            await _cacheService.SetCacheValueAsync(
                request.Key,
                request.Value
            );

            return Ok();
        }
    }
}
