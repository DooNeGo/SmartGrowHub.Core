using SmartGrowHub.Domain.Abstractions;
using SmartGrowHub.Domain.Common;

namespace SmartGrowHub.Domain.Model;

public sealed class Plant(
    Id<Plant> id,
    NonEmptyString name)
    : Entity<Plant>(id)
{
    private Plant(Plant original) : this(
        original.Id, original.Name)
    { }

    public NonEmptyString Name { get; init; } = name;

    public Plant UpdateName(NonEmptyString name) =>
        new(this) { Name = name };
}