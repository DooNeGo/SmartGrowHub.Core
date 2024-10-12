using SmartGrowHub.Domain.Common;
using SmartGrowHub.Domain.Exceptions;
using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Model;

public sealed record GrowHub(
    Id<GrowHub> Id,
    ImmutableArray<SensorMeasurement> Measurements,
    ImmutableArray<Setting> Settings,
    Option<Plant> Plant)
{
    private static readonly ItemAlreadyExistsException AlreadyExistsException =
        new(nameof(SensorMeasurement), nameof(GrowHub));

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(GrowHub? other) => other is not null && Id == other.Id;

    public Fin<GrowHub> AddMeasurement(SensorMeasurement reading) =>
        !Measurements.Contains(reading)
            ? this with { Measurements = Measurements.Add(reading) }
            : FinFail<GrowHub>(AlreadyExistsException);

    public Fin<GrowHub> AddOrUpdatePlant(Plant plant) =>
        this with { Plant = plant };

    public Fin<GrowHub> RemovePlant() =>
        this with { Plant = None };
}