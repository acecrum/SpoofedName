using CommandSystem;
using LabApi.Features.Wrappers;

namespace SpoofedName;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class SpoofCommand : ICommand, IUsageProvider
{
    public string Command => "spoof";
    public string[] Aliases => [];
    public string Description => "Spoofs the the executor's username";
    public string[] Usage => ["Name"];

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        var _jsonSaving = SpoofPlugin._jsonSaving;
        
        var cSender = Player.Get(sender);
        if (!sender.CheckPermission(PlayerPermissions.KickingAndShortTermBanning))
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
            case > 1:
                response = "Only one argument is allowed";
                return false;
        }
        var spoofName = arguments.ElementAt(0);

        cSender?.ReferenceHub.nicknameSync.MyNick = spoofName;

        if (cSender != null) _jsonSaving?.Save(cSender, spoofName);

        response = $"Spoofed to {spoofName}, rejoin for the name change to occur.";
        return true;
    }
}