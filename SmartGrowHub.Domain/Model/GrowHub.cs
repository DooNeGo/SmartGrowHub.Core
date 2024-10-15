using SmartGrowHub.Domain.Abstractions;
using SmartGrowHub.Domain.Common;
using System.Collections.Immutable;

namespace SmartGrowHub.Domain.Model;

public sealed class GrowHub(
    Id<GrowHub> id,
    ImmutableDictionary<Id<Setting>, Setting> settings,
    Option<Plant> plant)
    : Entity<GrowHub>(id)
{
    private static readonly Error SettingNotFound = Error.New("The grow hub setting was not found");

    private GrowHub(GrowHub original) : this(
        original.Id, original.Settings,
        original.Plant)
    { }

    public ImmutableDictionary<Id<Setting>, Setting> Settings { get; init; } = settings;

    public Option<Plant> Plant { get; init; } = plant;

    public GrowHub UpdatePlant(Option<Plant> plant) =>
        new(this) { Plant = plant };

    public Fin<GrowHub> UpdateSetting(Setting setting) =>
        Settings.ContainsKey(setting.Id)
            ? new GrowHub(this) { Settings = Settings.SetItem(setting.Id, setting) }
            : SettingNotFound;
}