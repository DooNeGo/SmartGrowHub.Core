namespace SmartGrowHub.Domain.Extensions;

public static class ErrorExtensions
{
    public static Error AddPrefix(this Error error, string prefix) =>
        Error.New($"{prefix} {error}", error);
}
