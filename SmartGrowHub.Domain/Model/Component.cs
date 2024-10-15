using SmartGrowHub.Domain.Abstractions;
using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed class Component(
    Id<Component> id,
    ComponentType type,
    int value,
    NonEmptyString unit)
    : Entity<Component>(id)
{
    public ComponentType Type { get; init; } = type;

    public int Value { get; init; } = value;

    public NonEmptyString Unit { get; init; } = unit;
}