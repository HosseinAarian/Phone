using MediatR;
using Phone.Application.Contract.Common.CachingBehaviors;

namespace Phone.Application.Contract.CommandsQueries.Phones;

public record GetAllPhoneQuery : IRequest<List<GetAllPhoneQueryResponse>>, ICacheable
{
    public string CacheKey => GetPhonesCacheKey.key;

    public TimeSpan? Expiration => TimeSpan.FromMinutes(5);
};

public static class GetPhonesCacheKey
{
    public static string key => "phones:all";
}

