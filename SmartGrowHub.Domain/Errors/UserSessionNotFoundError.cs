namespace SmartGrowHub.Domain.Errors;

public sealed record UserSessionNotFoundError : Error
{
    public override string Message => "The user's session was not found";

    public override bool IsExceptional => false;

    public override bool IsExpected => true;

    public override ErrorException ToErrorException() =>
        ErrorException.New(Message);
}
