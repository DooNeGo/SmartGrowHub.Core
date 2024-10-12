using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Exceptions;
using SmartGrowHub.Domain.Extensions;
using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Model;

public sealed record User(
    Id<User> Id,
    UserName UserName,
    Password Password,
    EmailAddress Email,
    NonEmptyString DisplayName,
    ImmutableArray<GrowHub> GrowHubs,
    ImmutableArray<UserSession> Sessions)
{
    private static readonly ItemAlreadyExistsException SessionAlreadyExistsException = new(nameof(UserSession), nameof(User));
    private static readonly ItemNotFoundException SessionNotFoundException = new(nameof(UserSession), nameof(User));
    private static readonly Error SessionAlreadyExistsError = Error.New(SessionAlreadyExistsException);
    private static readonly Error SessionNotFoundError = Error.New(SessionNotFoundException);

    public static User New(UserName userName, Password password, EmailAddress email, NonEmptyString displayName) =>
        new(new Id<User>(Ulid.NewUlid()), userName, password, email, displayName, [], []);

    public Fin<User> AddSession(UserSession session) =>
        Sessions.Contains(session)
            ? SessionAlreadyExistsError
            : this with { Sessions = Sessions.Add(session) };

    public Fin<(User, Option<Error>)> UpdateSessionTokens(
        RefreshToken oldToken, AuthTokens newTokens, DateTime now) =>
        Sessions
            .IndexOf(session => session.AuthTokens.RefreshToken == oldToken.Ulid)
            .Map(index => Sessions[index]
                .UpdateTokens(newTokens, now)
                .Match(
                    Succ: session => (Sessions.SetItem(index, session), None),
                    Fail: error => (Sessions.RemoveAt(index), Some(error))))
            .Match<Fin<(User, Option<Error>)>>(
                Some: tuple => (this with { Sessions = tuple.Item1 }, tuple.Item2),
                None: SessionNotFoundError);

    public Fin<User> RemoveSession(Id<UserSession> id) =>
        RemoveSession(session => session.Id == id);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(User? other) => other is not null && Id == other.Id;

    private Fin<User> RemoveSession(Func<UserSession, bool> predicate) =>
        Sessions
            .IndexOf(predicate)
            .Match<Fin<User>>(
                Some: index => this with { Sessions = Sessions.RemoveAt(index) },
                None: SessionNotFoundError);
}