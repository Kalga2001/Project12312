using System;
using System.Threading.Tasks;

namespace OnlineShop.Application.Common.Interfaces.Repositories
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}