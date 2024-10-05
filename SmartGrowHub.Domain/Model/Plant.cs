using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed record Plant(Id<Plant> Id, NonEmptyString Name)
{
    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Plant? other) => other is not null && Id == other.Id;
}