using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Model;
using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Extensions;

public static class ImmutableDictionaryExtensions
{
    public static Option<UserSession> FindByRefreshToken(
        this ImmutableDictionary<Id<UserSession>, UserSession> dictionary,
        RefreshToken refreshToken) =>
        Optional(dictionary.FirstOrDefault(keyValuePair => keyValuePair.Value.AuthTokens.RefreshToken == refreshToken).Value);
}
