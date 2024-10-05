using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed record Component(
    Id<Component> Id,
    ComponentType Type,
    int Value,
    NonEmptyString Unit)
{
    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Component? other) => other is not null && Id == other.Id;
}