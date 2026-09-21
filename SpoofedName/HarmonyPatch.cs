using HarmonyLib;

namespace SpoofedName;

[HarmonyLib.HarmonyPatch(typeof(NicknameSync), nameof(NicknameSync.MyNick), MethodType.Setter)]
public class HarmonyPatch
{

    [HarmonyPrefix]
    public static void prefix(ref string value)
    {
        value = "Spoofed Name";
    }
    
}