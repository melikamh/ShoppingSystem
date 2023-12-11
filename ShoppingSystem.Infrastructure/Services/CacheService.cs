using Microsoft.Extensions.Caching.Memory;

namespace ShoppingSystem.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        public T Get<T>(string key)
        {
            T value;
            if (_memoryCache.TryGetValue(key, out value))
            {
                return value;
            }
            return value;
        }

        public T GetOrSet<T>(string key, Func<T> getItemCallback, TimeSpan expirationTime)
        {
            if (_memoryCache.TryGetValue(key, out T cachedItem))
            {
                return cachedItem;
            }

            var newItem = getItemCallback();
            _memoryCache.Set(key, newItem, expirationTime);

            return newItem;
        }
    }
}