using Core.Caching;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Data.Caching
{
    public class InMemoryCacheManager : ICacheService
    {
        private readonly IMemoryCache _inMemoryCache;

        public InMemoryCacheManager(IMemoryCache inMemoryCache)
        {
            _inMemoryCache = inMemoryCache;
        }

        public void RemoveCache(string key)
        {
            _inMemoryCache.Remove(key);
        }

        public void SetToCache<TValueType>(string key, TValueType value)
        {
            _inMemoryCache.Set(key, value);
        }

        public Tuple<bool, TEntity> GetFromCacheIfExists<TEntity>(string key)
        {
            var exists = _inMemoryCache.TryGetValue(key, out TEntity entity);
            if (exists)
                return new Tuple<bool, TEntity>(true, entity);

            return new Tuple<bool, TEntity>(false, default);
        }
    }
}
