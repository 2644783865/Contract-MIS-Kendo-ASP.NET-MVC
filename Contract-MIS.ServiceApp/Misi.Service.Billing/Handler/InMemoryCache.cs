using System;
using System.Runtime.Caching;

namespace Misi.Service.Billing.Handler
{
    public class InMemoryCache
    {
        private static volatile InMemoryCache _cache;
        private static readonly object SyncRoot1 = new object();

        private ObjectCache _cachedObjects;
        private CacheItemPolicy _cachingPolicy;

        public static InMemoryCache Instance
        {
            get
            {
                if (_cache != null) return _cache;
                lock (SyncRoot1)
                {
                    if (_cache == null)
                    {
                        _cache = new InMemoryCache
                        {
                            _cachedObjects = MemoryCache.Default,
                            _cachingPolicy = new CacheItemPolicy
                            {
                                Priority = CacheItemPriority.NotRemovable
                            }
                        };
                    }
                }
                return _cache;
            }
        }

        public void Cache(string key, object value)
        {
            //System.Diagnostics.Debug.WriteLine("SET >>>> KEY = " + key);
            _cachedObjects.Add(key, value, _cachingPolicy);
        }

        public object GetCached(string key)
        {
            //System.Diagnostics.Debug.WriteLine("GET >>>> KEY = " + key);
            if (_cachedObjects.Contains(key))
                return _cachedObjects.Get(key);
            return null;
        }

        public void ClearCached(string key)
        {
            //System.Diagnostics.Debug.WriteLine("CLR >>>> KEY = " + key);
            if (_cachedObjects.Contains(key))
                _cachedObjects.Remove(key);
        }
    }
}