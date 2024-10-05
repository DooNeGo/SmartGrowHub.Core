namespace SmartGrowHub.Domain.Common;

public sealed record RefreshToken(
    in Ulid Ulid,
    in DateTime Expires)
    : DomainType<RefreshToken, (string, DateTime)>,
      DomainType<RefreshToken, string>
{
    public static implicit operator string(RefreshToken token) => token.Ulid.ToString();
    public static implicit operator Ulid(RefreshToken token) => token.Ulid;
    public static implicit operator (Ulid, DateTime)(RefreshToken token) => (token.Ulid, token.Expires);
    public static explicit operator RefreshToken((string, DateTime) value) => From(value).ThrowIfFail();

    public static Fin<RefreshToken> From((string, DateTime) repr) =>
        Ulid.TryParse(repr.Item1, out Ulid ulid)
            ? new RefreshToken(in ulid, in repr.Item2)
            : Error.New("Invalid refresh token");

    public (string, DateTime) To() =>
        (Ulid.ToString(), Expires);

    static Fin<RefreshToken> DomainType<RefreshToken, string>.From(string repr)
    {
        string[] result = repr.Split(' ');
        if (result.Length < 2) return Error.New("Can not create refresh token from 1 value");

        return DateTime.TryParse(result[1], out DateTime expires)
            ? From((result[0], expires))
            : Error.New("Invalid date time format");
    }

    string DomainType<RefreshToken, string>.To() => $"{Ulid} {Expires}";
}