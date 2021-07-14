using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raymaker.RedisTutorial.Models;
using Raymaker.RedisTutorial.Services;
using System.Threading.Tasks;

namespace Raymaker.RedisTutorial.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CacheController : ControllerBase
    {
        private readonly ILogger<CacheController> logger;
        private readonly ICacheService cacheService;

        public CacheController(ILogger<CacheController> logger, ICacheService cacheService)
        {
            this.logger = logger;
            this.cacheService = cacheService;
        }

        // GET /api/cache/test
        [HttpGet("cache/{key}")]
        public async Task<IActionResult> GetCacheValue([FromRoute] string key)
        {
            var value = await cacheService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ? (IActionResult) NotFound() : Ok(value);
        }

        // POST /api/cache
        [HttpPost("cache")]
        public async Task<IActionResult> SetCacheValue([FromBody] NewCacheEntry request)
        {
            await cacheService.SetCacheValueAsync(request.Key, request.Value);
            return Ok();
        }
    }
}
