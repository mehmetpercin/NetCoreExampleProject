using System;

namespace Core.Caching
{
    public interface ICacheService
    {
        void SetToCache<TValueType>(string key,TValueType value);
        Tuple<bool,TEntity> GetFromCacheIfExists<TEntity>(string key);
        void RemoveCache(string key);
    }
}
