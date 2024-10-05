namespace SmartGrowHub.Domain.Exceptions;

public sealed class InternalException(Exception? innerException = null)
    : Exception("Internal error", innerException);