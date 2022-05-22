using Ocelot.Cache;

namespace DemoOcelot.midware
{
    public class OcelotCache<CachedResponse> : IOcelotCache<CachedResponse>
    {
        private class CacheModel
        {
            public string Region { get; set; }
            public TimeSpan TtlSeconds { get; set; }
            public CachedResponse CachedResponse { get; set; }
        }

        private static Dictionary<string, CacheModel> _cache = new Dictionary<string, CacheModel>();

        public void Add(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            _cache[key] = new CacheModel() { Region = region, TtlSeconds = ttl, CachedResponse = value };
        }

        public void AddAndDelete(string key, CachedResponse value, TimeSpan ttl, string region)
        {
            _cache[key] = new CacheModel() { Region = region, TtlSeconds = ttl, CachedResponse = value };
        }

        public void ClearRegion(string region)
        {
            throw new NotImplementedException();
        }

        public CachedResponse Get(string key, string region)
        {
            if (_cache.ContainsKey(key))
            {
                return _cache[key].CachedResponse;
            }
            return default;
        }
    }
}
