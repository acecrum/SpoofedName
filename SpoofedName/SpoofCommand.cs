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
        Player? cSender = Player.Get(sender);
        if (!sender.CheckPermission(PlayerPermissions.PlayersManagement))
        {
            response = "You don't have permission to use this command.";
            return false;
        }
        switch (arguments.Count)
        {
            case 0:
                response = "spoof [Name]";
                return false;
            case > 1:
                response = "Only one argument is allowed";
                return false;
        }
        var spoofName = arguments.ElementAt(0);

        cSender?.ReferenceHub.nicknameSync.MyNick = spoofName;
        
        //CentralAuth.PlayerAuthenticationManager
        
        response = $"Spoofed to {spoofName}, rejoin for the name change to occur.";
        return true;
    }
}