using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using Newtonsoft.Json;
using System.Collections.Generic;
using GameOffsets2.Native;
using System.Drawing;

namespace Ground_Items_With_Linq;

public class Ground_Items_With_LinqSettings : ISettings
{
    //Mandatory setting to allow enabling/disabling your plugin
    public ToggleNode Enable { get; set; } = new(false);

    [Menu(null, "Display debug strings")]
    public ToggleNode Debug { get; set; } = new(false);

    public List<GroundRule> GroundRules { get; set; } = [];
    public RangeNode<int> UpdateTimer { get; set; } = new(500, 0, 5000);
    public RangeNode<float> TextSize { get; set; } = new(1f, 1f, 20f);

    public UniqueIdentificationSettings UniqueIdentificationSettings { get; set; } = new();
    public ToggleNode EnableTextDrawing { get; set; } = new(true);
    public ToggleNode IgnoreFullscreenPanels { get; set; } = new(false);
    public ToggleNode IgnoreRightPanels { get; set; } = new(false);
    public TextNode FontOverride { get; set; } = new("");
    public ToggleNode ScaleFontWhenCustom { get; set; } = new(false);
    public RangeNode<int> ItemSpacing { get; set; } = new(5, 1, 60);
    public ToggleNode AlignItemTextToCenter { get; set; } = new(true);
    public ToggleNode DrawCompass { get; set; } = new(true);
    public ToggleNode AlignCompassToCenter { get; set; } = new(true);

    [Menu(null, "Use a much more performant label list, only containing labels which are actually visible (items hidden by the filter or by pressing Z will not show up)")]
    public ToggleNode UseFastLabelList { get; set; } = new(false);

    [JsonProperty("textPadding2")]
    public RangeNode<Vector2i> TextPadding { get; set; } = new(new Vector2i(5, 2), Vector2i.Zero, Vector2i.One * 60);

    public RangeNode<int> BorderWidth { get; set; } = new(1, 1, 20);
    public RangeNode<int> LabelShift { get; set; } = new(0, -600, 600);
    public ToggleNode OrderByDistance { get; set; } = new(true);

    public ToggleNode EnableMapDrawing { get; set; } = new(true);
    public ColorNode MapLineColor { get; set; } = new(Color.FromArgb(255, 0, 255, 214));
    public RangeNode<float> MapLineThickness { get; set; } = new(2.317f, 1f, 10f);

    public SocketDisplaySettings SocketDisplaySettings { get; set; } = new();

    [JsonIgnore]
    public ButtonNode ReloadFilters { get; set; } = new();

    [Menu(@"Use a Custom ""\config\custom_folder"" folder")]
    public TextNode CustomConfigDir { get; set; } = new();
}

[Submenu]
public class SocketDisplaySettings
{
    public ToggleNode ShowSockets { get; set; } = new(true);
    public RangeNode<int> SocketSize { get; set; } = new(6, 1, 60);
    public RangeNode<int> SocketSpacing { get; set; } = new(4, 4, 60);
    public RangeNode<int> SocketPadding { get; set; } = new(5, 0, 60);
    public ColorNode RedSocketColor { get; set; } = Color.FromArgb(255, 13, 50, 201);
    public ColorNode GreenSocketColor { get; set; } = Color.FromArgb(255, 158, 202, 13);
    public ColorNode BlueSocketColor { get; set; } = Color.FromArgb(255, 88, 130, 254);
    public ColorNode WhiteSocketColor { get; set; } = Color.White;
    public ColorNode AbyssalSocketColor { get; set; } = Color.FromArgb(255, 59, 59, 59);
    public ColorNode ResonatorSocketColor { get; set; } = Color.FromArgb(255, 249, 149, 13);
    public ColorNode LinkColor { get; set; } = Color.FromArgb(255, 195, 195, 195);
    public RangeNode<int> LinkWidth { get; set; } = new(4, 2, 20);
}

[Submenu]
public class UniqueIdentificationSettings
{
    [JsonIgnore]
    public ButtonNode RebuildUniqueItemArtMappingBackup { get; set; } = new();

    [Menu(null, "Use if you want to ignore what's in game memory and rely only on your custom/builtin file")]
    public ToggleNode IgnoreGameUniqueArtMapping { get; set; } = new(false);
}

public class GroundRule(string name, string location, bool enabled)
{
    public string Name { get; set; } = name;
    public string Location { get; set; } = location;
    public bool Enabled { get; set; } = enabled;
}