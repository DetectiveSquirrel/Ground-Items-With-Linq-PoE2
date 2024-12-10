using ExileCore2;
using ExileCore2.PoEMemory.Components;
using ExileCore2.PoEMemory.Elements;
using ExileCore2.PoEMemory.MemoryObjects;
using ExileCore2.Shared.Enums;
using ExileCore2.Shared.Helpers;
using ItemFilterLibrary;
using System.Collections.Generic;
using System.Linq;
using ExileCore2.PoEMemory;
using System.Drawing;
using Vector2 = System.Numerics.Vector2;

namespace Ground_Items_With_Linq;

public class CustomItemData(
    Entity queriedItem,
    Entity worldEntity,
    Element label,
    GameController gc,
    IReadOnlyDictionary<string, List<string>> uniqueNameCandidates) : ItemData(queriedItem, worldEntity, gc)
{
    public Color TextColor { get; set; } = label.TextColor;
    public Color BorderColor { get; set; } = label.BordColor;
    public Color BackgroundColor { get; set; } = label.BgColor;
    public string LabelText { get; set; } = label.Text;
    public long LabelAddress { get; set; } = label.Address;
    public bool? IsWanted { get; set; }
    public Vector2 Location { get; set; } = worldEntity.GridPos;

    public List<string> UniqueNameCandidates { get; set; }
        = queriedItem.TryGetComponent<Mods>(out var mods) && !mods.Identified && mods.ItemRarity == ItemRarity.Unique
            ? (uniqueNameCandidates.GetValueOrDefault(
                  queriedItem.GetComponent<RenderItem>()
                             ?.ResourcePath
              ) ?? Enumerable.Empty<string>())
              .Where(x => !x.StartsWith("Replica "))
              .ToList() : [];

    public float DistanceCustom { get; set; }

    public override string ToString() => $"{Name}, LabelID({LabelAddress}), IsWanted({IsWanted})";
}

public static class ItemExtensions
{
    public static void UpdateDynamicCustomData(this CustomItemData item)
    {
        if (item.IsWanted == true)
        {
            item.DistanceCustom = item.GameController.Player.GridPos.Distance(item.Location);
        }
    }
}