using System.Reflection;

namespace NextbooruLite.Helpers;

public static class QueryHelper
{
    public static IEnumerable<string> GetOrderableFields<T>()
        where T: class
    {
        var type = typeof(T);
        return type.GetProperties()
            .Where(p => p.GetCustomAttribute<OrderableAttribute>() is not null)
            .Select(p => p.Name);
    }
}
