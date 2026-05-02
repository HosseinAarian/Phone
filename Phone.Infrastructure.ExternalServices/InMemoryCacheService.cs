using Microsoft.Extensions.Caching.Memory;
using Phone.Application.Contract.Interfaces;

namespace Phone.Infrastructure.ExternalServices;

public class InMemoryCacheService(
    IMemoryCache cache)
    : ICacheService
{
    public Task<T?> GetAsync<T>(string key)
        => Task.FromResult(cache.TryGetValue(key, out T value) ? value : default);

    public Task SetAsync<T>(string key, T value, TimeSpan? absoluteExpiration = null)
    {
        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = absoluteExpiration ?? TimeSpan.FromMinutes(10)
        };
        cache.Set(key, value, options);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key)
    {
        cache.Remove(key);
        return Task.CompletedTask;
    }


}
