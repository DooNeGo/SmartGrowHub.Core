using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Extensions;

public static class ImmutableArrayExtensions
{
    public static Option<int> IndexOf<T>(this ImmutableArray<T> array, Func<T, bool> predicate)
    {
        ReadOnlySpan<T> span = array.AsSpan();

        for (int i = 0; i < span.Length; i++)
        {
            if (predicate(span[i])) return i;
        }

        return None;
    }
}
