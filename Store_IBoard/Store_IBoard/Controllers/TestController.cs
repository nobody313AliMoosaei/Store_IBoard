using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IDistributedCache _dbCach;
        public TestController(IDistributedCache cach)
        {
            _dbCach = cach;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SetInRedis(string Value)
        {
            var key = Guid.NewGuid().ToString();
            _dbCach.SetString(key, Value);
            return Ok(key);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string Key)
        {
            return Ok(await _dbCach.GetStringAsync(Key));
        }


    }
}
