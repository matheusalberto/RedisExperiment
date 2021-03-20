using StackExchange.Redis;
using System.Threading.Tasks;

namespace RedisExperiment.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var redisDatabase = _connectionMultiplexer.GetDatabase();
            return await redisDatabase.StringGetAsync(key);
        }

        public async Task SetCacheValueAsync(string key, string value)
        {
            var redisDatabase = _connectionMultiplexer.GetDatabase();
            await redisDatabase.StringSetAsync(key, value);
        }
    }
}
