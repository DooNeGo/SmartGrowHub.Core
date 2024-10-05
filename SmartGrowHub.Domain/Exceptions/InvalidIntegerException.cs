namespace SmartGrowHub.Domain.Exceptions;

public sealed class InvalidIntegerException(string message)
    : Exception(message);