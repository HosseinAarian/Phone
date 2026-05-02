namespace Phone.Application.Contract.Common.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class InvalidateCacheAttribute : Attribute
{
    public string CacheKey { get; }

    public InvalidateCacheAttribute(string cacheKey)
    {
        CacheKey = cacheKey;
    }
}
