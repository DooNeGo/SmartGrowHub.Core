using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed record UserSession(
    Id<UserSession> Id,
    Id<User> UserId,
    AuthTokens AuthTokens)
{
    private static readonly Error RefreshTokenExpiredError =
        Error.New("The refresh token has been already expired");

    public static UserSession New(Id<User> userId, AuthTokens tokens) =>
        new(new Id<UserSession>(Ulid.NewUlid()), userId, tokens);

    public Fin<UserSession> UpdateTokens(AuthTokens tokens, DateTime now) =>
        AuthTokens.RefreshToken.Expires > now
            ? this with { AuthTokens = tokens }
            : RefreshTokenExpiredError;

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(UserSession? other) => other is not null && Id == other.Id;
}
