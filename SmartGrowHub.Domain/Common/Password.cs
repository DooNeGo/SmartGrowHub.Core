using SmartGrowHub.Domain.Extensions;
using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Common;

public abstract record Password
{
    public static Password Empty { get; } = new EmptyPassword();

    public static Fin<Password> FromPlainText(string plainText) =>
        PlainTextPassword
            .From(plainText)
            .Map(password => (Password)password);

    public static Fin<Password> FromHash(ImmutableArray<byte> hash) =>
        HashedPassword
            .From(hash)
            .Map(password => (Password)password);

    public T Match<T>(Func<string, T> plainText, Func<ImmutableArray<byte>, T> hash, Func<T> empty) =>
        this switch
        {
            PlainTextPassword plainTextPassword => plainText(plainTextPassword.To()),
            HashedPassword hashedPassword => hash(hashedPassword.To()),
            EmptyPassword => empty(),
            _ => throw new InvalidOperationException()
        };

    private sealed record PlainTextPassword : Password, DomainType<PlainTextPassword, string>
    {
        private const int MinimumLength = 8;
        private const string Prefix = "Password:";

        private readonly string _value;

        private PlainTextPassword(string value) => _value = value;

        public static Fin<PlainTextPassword> From(string repr)
        {
            Fin<PlainTextPassword> result =
                from nonEmpty in NonEmptyString.From(repr.Trim())
                from latin in LatinString.From(nonEmpty)
                from minLength in NonNegativeInteger.From(MinimumLength)
                from bounded in BoundedString.From(latin, minLength, None)
                select new PlainTextPassword(bounded);

            return result.BiMap(
                x => x,
                error => error.AddPrefix(Prefix));
        }

        public string To() => _value;

        public override string ToString() => _value;
    }

    private sealed record HashedPassword : Password, DomainType<HashedPassword, ImmutableArray<byte>>
    {
        private const int MinLength = 48;

        private readonly ImmutableArray<byte> _value;

        private HashedPassword(ImmutableArray<byte> value) => _value = value;

        public static Fin<HashedPassword> From(ImmutableArray<byte> repr) =>
            repr.Length >= MinLength
                ? new HashedPassword(repr)
                : Error.New("Invalid hashed password length");

        public ImmutableArray<byte> To() => _value;
    }

    private sealed record EmptyPassword : Password;
}