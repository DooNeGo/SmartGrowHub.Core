namespace SmartGrowHub.Domain.Errors;

public enum DomainErrorCode
{
    RefreshTokenExpired,
    RegisterFailed,
    LogInFailed,
    SessionNotFound,
    SettingNotFound,
    UserNotFound
}

public static class DomainErrors
{
    public static readonly Error RefreshTokenExpiredError =
        Error.New((int)DomainErrorCode.RefreshTokenExpired, "The refresh token has already expired");

    public static readonly Error SessionNotFoundError =
        Error.New((int)DomainErrorCode.SessionNotFound, "The session was not found");

    public static readonly Error SettingNotFoundError =
        Error.New((int)DomainErrorCode.SessionNotFound, "The setting was not found");

    public static readonly Error UserNotFoundError =
        Error.New((int)DomainErrorCode.UserNotFound, "The user was not found");

    public static readonly Error LogInFailedError =
        Error.New((int)DomainErrorCode.UserNotFound, "Invalid username or password");
}
