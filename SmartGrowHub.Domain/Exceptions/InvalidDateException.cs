namespace SmartGrowHub.Domain.Exceptions;

public sealed class InvalidDateException(string message) :
    Exception(message);
