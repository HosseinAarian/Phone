using MediatR;
using Phone.Application.Contract.Common.Attributes;
using Phone.Application.Contract.Interfaces;

namespace Phone.Application.Contract.Common.CachingBehaviors;

public class CacheInvalidationBehavior<TRequest, TResponse>(
    ICacheService cacheService)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request,
                                  RequestHandlerDelegate<TResponse> next,
                                  CancellationToken cancellationToken)
    {
        var response = await next();

        var cacheInvalidationAttributes = request.GetType()
            .GetCustomAttributes(typeof(InvalidateCacheAttribute), true)
            .Cast<InvalidateCacheAttribute>()
            .ToList();

        foreach (var item in cacheInvalidationAttributes)
        {
            await cacheService.RemoveAsync(item.CacheKey);
        }

        return response;
    }
}
