using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Redis
{
    public interface IRedisCacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan expiration);
        Task RemoveAsync(string key);
    }
    public class RedisCacheService(IDistributedCache _cache) : IRedisCacheService
    {
        public async Task<T?> GetAsync<T>(string key)
        {
            var cacheData = await _cache.GetStringAsync(key);
            return cacheData != null ? JsonConvert.DeserializeObject<T>(cacheData) : default;
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            var serializeData = JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Newtonsoft.Json.Formatting.None
            });

            await _cache.SetStringAsync(key, serializeData, options);
        }
    }
}
