using System;
using System.Linq;
using System.Runtime.Caching;

namespace Common.Cache
{
     public class MemoryCacheHelper
    {
        private static readonly Object _locker = new object();
        #region public function
        /// <summary>
        /// 缓存 需要做空判断，在没有值得时候，会返回一个 null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachePopulate"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static T GetCacheItem<T>(String key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
            if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        var item = new CacheItem(key, cachePopulate());
                        if (item.Value == null)
                        {
                            return (T)MemoryCache.Default[key];
                        }
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        [Obsolete("非必要请勿执行此方法")]
        public static void ClearAllCache()
        {
            lock (_locker)
            {
                //MemoryCache.Default.AddOrGetExisting()
                //MemoryCache.Host.
                var keys = MemoryCache.Default.Select(a => a.Key);
                foreach (var item in keys)
                {
                    MemoryCache.Default.Remove(item);
                }
            }
        }

        /// <summary>
        /// 移除单个缓存
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }
            lock (_locker)
            {
                if (MemoryCache.Default.Contains(key))
                {
                    MemoryCache.Default.Remove(key);
                }
            }
        }

        /// <summary>
        /// 移除多个缓存
        /// </summary>
        /// <param name="keys"></param>
        public static void RemoveCaches(string[] keys)
        {
            foreach (var item in keys)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    continue;
                }
                RemoveCache(item);
            }
        }

        #endregion

        #region private function
        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }
            policy.Priority = CacheItemPriority.NotRemovable;
            policy.Priority = CacheItemPriority.Default;

            return policy;

        }

        #endregion

    }
}
