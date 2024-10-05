using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed record UserSession(
    Id<UserSession> Id,
    Id<User> UserId,
    AuthTokens AuthTokens)
{
    public static UserSession New(Id<User> userId, AuthTokens tokens) =>
        new(new Id<UserSession>(Ulid.NewUlid()), userId, tokens);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(UserSession? other) => other is not null && Id == other.Id;
}
