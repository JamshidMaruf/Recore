using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Recore.Service.Helpers;


public static class CacheService
{
    private static MemoryCache cache;

    public static string GetCachedData(string key) =>
        cache.Get(key) as string;

    public static void SetDataToCache(string key, string data, int bestBefore=24*7)
    {
        var etag = data.GetHashCode().ToString();
        cache.Set(key, etag, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(bestBefore)
        });
    }
}
