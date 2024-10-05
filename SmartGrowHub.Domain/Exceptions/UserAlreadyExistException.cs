namespace SmartGrowHub.Domain.Exceptions;

public sealed class UserAlreadyExistException()
    : Exception("A user with such user name or email already exists");