using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Model;

public sealed record GrowHub(
    Id<GrowHub> Id,
    ImmutableArray<SensorMeasurement> SensorMeasurements,
    ImmutableArray<Setting> Settings,
    Option<Id<Plant>> Plant)
{
    private static readonly ItemAlreadyExistsException AlreadyExistsException =
        new(nameof(SensorMeasurement), nameof(GrowHub));

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub? other) => other is not null && Id == other.Id;

    public Fin<GrowHub> AddReading(SensorMeasurement reading) =>
        !SensorMeasurements.Contains(reading)
            ? this with { SensorMeasurements = SensorMeasurements.Add(reading) }
            : FinFail<GrowHub>(AlreadyExistsException);
}