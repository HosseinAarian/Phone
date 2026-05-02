using MediatR;
using Phone.Application.Contract.Interfaces;

namespace Phone.Application.Contract.Common.CachingBehaviors;

public class ChachingBehavior<TRequest, TResponse>(ICacheService cacheService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICacheable
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cacheKey = request.CacheKey;

        var cacheData = await cacheService.GetAsync<TResponse>(cacheKey);
        if (cacheData is not null)
            return cacheData;

        var response = await next();

        await cacheService.SetAsync(cacheKey, response, request.Expiration);

        return response;
    }
}

public interface ICacheable
{
    string CacheKey { get; }
    TimeSpan? Expiration { get; }
}
