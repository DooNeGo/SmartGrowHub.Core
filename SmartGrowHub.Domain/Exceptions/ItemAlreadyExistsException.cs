namespace SmartGrowHub.Domain.Exceptions;

public sealed class ItemAlreadyExistsException(string itemName, string placeName)
    : Exception($"The {itemName} already exists in the {placeName}");