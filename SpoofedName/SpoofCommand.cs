using System.Diagnostics.CodeAnalysis;
using CommandSystem;

namespace SpoofedName;

public class SpoofCommand : ICommand, IUsageProvider
{
    public string Command => "spoof";
    public string[] Aliases => [];
    public string Description => "Spoofs the the executor's username";
    public string[] Usage => ["Name"];
    
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, [UnscopedRef] out string response)
    {
        if (!sender.CheckPermission(PlayerPermissions.PlayersManagement))
        {
            response = "You don't have permission to use this command.";
            return false;
        }
        
        response = "Spoofed";
        return true;
    }
}