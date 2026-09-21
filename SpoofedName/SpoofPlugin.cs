using HarmonyLib;
using LabApi.Loader.Features.Plugins;
using LabApi.Features;
using LabApi.Features.Console;

namespace SpoofedName;
public class SpoofPlugin : Plugin
{
    public override string Name { get; } = "Spoofed Name";
    public override string Description { get; } = "Staff can change their name without having to change their Steam name";
    public override string Author { get; } = "acecrum";
    public override Version Version { get; } = new Version(1, 1, 0);
    public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);

    public static JsonSaving? _jsonSaving;
    private Harmony? _harmony;
    
    public override void Enable()
    {
        _harmony = new  Harmony("acecrum.spoofedname");
        _harmony.PatchAll();
        _jsonSaving = new JsonSaving("SpoofedNames");
    }

    public override void Disable()
    {
        _harmony?.UnpatchAll();
    }
}