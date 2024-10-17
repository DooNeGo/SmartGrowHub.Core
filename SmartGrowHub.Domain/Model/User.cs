using SmartGrowHub.Domain.Abstractions;
using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Common.Password;

namespace SmartGrowHub.Domain.Model;

public sealed class User(
    Id<User> id,
    UserName userName,
    Password password,
    EmailAddress emailAddress,
    NonEmptyString displayName)
    : Entity<User>(id)
{
    private User(User original) : this(
        original.Id, original.UserName,
        original.Password, original.Email,
        original.DisplayName)
    { }

    public UserName UserName { get; init; } = userName;

    public Password Password { get; init; } = password;

    public EmailAddress Email { get; init; } = emailAddress;

    public NonEmptyString DisplayName { get; init; } = displayName;

    public static User New(UserName userName, Password password, EmailAddress email, NonEmptyString displayName) =>
        new(new Id<User>(Ulid.NewUlid()), userName, password, email, displayName);

    public User UpdatePassword(Password password) =>
        new(this) { Password = password };
}