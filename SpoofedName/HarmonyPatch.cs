using HarmonyLib;

namespace SpoofedName;

[HarmonyLib.HarmonyPatch(typeof(NicknameSync), nameof(NicknameSync.MyNick), MethodType.Setter)]
public class HarmonyPatch
{

    [HarmonyPrefix]
    public static void prefix(NicknameSync __instance, ref string? value)
    {
        var hub = __instance.gameObject.GetComponent<ReferenceHub>();

        if (hub == null) return;

        var userId = hub.authManager.UserId;
        
        if (SpoofPlugin._jsonSaving?.TryGet(userId, out var spoofName) == true)
            value = spoofName;
    }
}