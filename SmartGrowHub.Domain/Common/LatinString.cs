using SmartGrowHub.Domain.Attributes;

namespace SmartGrowHub.Domain.Common;

public sealed record LatinString : DomainType<LatinString, string>
{
    private const string ErrorMessage =
        "The value must consist only of Latin letters, digits and special characters";

    private static readonly LatinOnlyAttribute Attribute = new(ErrorMessage);

    private readonly string _value;

    private LatinString(string value) => _value = value;

    public static implicit operator string(LatinString value) => value.To();
    public static explicit operator LatinString(string value) => From(value).ThrowIfFail();

    public static Fin<LatinString> From(string rawValue) =>
        Attribute.IsValid(rawValue).Map(v => new LatinString(v));

    public string To() => _value;

    public override string ToString() => To();
}