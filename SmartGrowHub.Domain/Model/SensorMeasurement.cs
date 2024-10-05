using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed record SensorMeasurement(
    Id<SensorMeasurement> Id,
    SensorType Type,
    NonEmptyString Value,
    NonEmptyString Unit,
    CreatedAt CreatedAt)
{
    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(SensorMeasurement? other) => other is not null && Id == other.Id;
}