using CommandSystem;
using LabApi.Features.Permissions;
using LabApi.Features.Wrappers;

namespace SpoofedName;

[CommandHandler(typeof(ClientCommandHandler))]
public class SpoofCommand : ICommand, IUsageProvider
{
    public string Command => "spoof";
    public string[] Aliases => [];
    public string Description => "Spoofs the executor's username";
    public string[] Usage => ["Name"];

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var _jsonSaving = SpoofPlugin._jsonSaving;
        
        var cSender = Player.Get(sender);
        if (!sender.HasPermission("acecrum.spoofname.spoof"))
        {
            response = "You don't have permission to use this command.";
            return false;
        }
        switch (arguments.Count)
        {
            case 0:
                if (cSender?.UserId != null) _jsonSaving?.Delete(cSender.UserId);
                response = "Spoof removed, rejoin for the name change to occur.";
                return true;
        }
        var spoofName = string.Join(" ", arguments.Skip(0));

        if (cSender != null) _jsonSaving?.Save(cSender, spoofName);
        
        response = $"Spoofed to {spoofName}, rejoin for the name change to occur.";
        return true;
    }
}