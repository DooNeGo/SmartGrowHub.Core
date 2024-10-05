namespace SmartGrowHub.Domain.Exceptions;

public sealed class InvalidStringException(string message)
    : Exception(message);