using LabApi.Loader.Features.Plugins;
using LabApi.Features;

namespace SpoofedName;

public class SpoofPlugin : Plugin
{
    public override string Name { get; } = "Spoofed Name";
    public override string Description { get; } = "Staff can change their name on everyones clients without having to change their Steam name";
    public override string Author { get; } = "acecrum";
    public override Version Version { get; } = new Version(1, 0, 0);
    public override Version RequiredApiVersion { get; } = new (LabApiProperties.CompiledVersion);
    
    public override void Enable()
    {
        
    }

    public override void Disable()
    {
        
    }
}