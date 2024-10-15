using SmartGrowHub.Domain.Abstractions;
using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed class UserSession(
    Id<UserSession> id,
    Id<User> userId,
    AuthTokens authTokens)
    : Entity<UserSession>(id)
{
    private static readonly Error RefreshTokenExpiredError =
        Error.New("The refresh token has been already expired");

    private UserSession(UserSession original) : this(
        original.Id, original.UserId, original.AuthTokens)
    { }

    public Id<User> UserId { get; init; } = userId;

    public AuthTokens AuthTokens { get; init; } = authTokens;

    public static UserSession New(Id<User> userId, AuthTokens tokens) =>
        new(new Id<UserSession>(Ulid.NewUlid()), userId, tokens);

    public UserSession UpdateTokens(AuthTokens tokens) =>
        new(this) { AuthTokens = tokens };
}
