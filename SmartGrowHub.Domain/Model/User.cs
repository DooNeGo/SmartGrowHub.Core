using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed record User(
    Id<User> Id,
    UserName UserName,
    Password Password,
    EmailAddress Email,
    NonEmptyString DisplayName)
{
    public static Fin<User> New(string userNameRaw, string passwordRaw, string emailRaw, string displayNameRaw) =>
        from userName in UserName.From(userNameRaw)
        from password in Password.FromPlainText(passwordRaw)
        from email in EmailAddress.From(emailRaw)
        from displayName in NonEmptyString.From(displayNameRaw)
        let userId = new Id<User>(Ulid.NewUlid())
        select new User(userId, userName, password, email, displayName);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(User? other) => other is not null && Id == other.Id;
}