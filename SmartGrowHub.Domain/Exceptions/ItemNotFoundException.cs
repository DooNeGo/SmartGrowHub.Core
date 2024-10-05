namespace SmartGrowHub.Domain.Exceptions;

public sealed class ItemNotFoundException(string itemName, Option<string> placeName)
    : Exception(placeName.Match(
        Some: place => $"The '{itemName}' was not found in the {place}",
        None: $"The '{itemName}' was not found"));