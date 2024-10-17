using SmartGrowHub.Domain.Extensions;

namespace SmartGrowHub.Domain.Common.Password;

public sealed record PlainTextPassword : Password, DomainType<PlainTextPassword, string>
{
    private const int MinimumLength = 8;
    private const string Prefix = "Password:";

    private readonly string _value;

    private PlainTextPassword(string value) => _value = value;

    public static implicit operator string(PlainTextPassword password) => password.To();
    public static explicit operator PlainTextPassword(string value) => From(value).ThrowIfFail();

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
