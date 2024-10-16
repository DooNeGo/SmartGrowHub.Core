namespace SmartGrowHub.Domain.Errors;

public sealed record RefreshTokenExpiredError : Error
{
    public override string Message => "The refresh token has already expired";

    public override bool IsExceptional => false;

    public override bool IsExpected => true;

    public override ErrorException ToErrorException() =>
        ErrorException.New(Message);
}
