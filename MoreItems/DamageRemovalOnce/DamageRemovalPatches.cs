using Gameplay.GameControllers.Entities;
using Gameplay.GameControllers.Penitent;
using Gameplay.GameControllers.Penitent.Damage;
using HarmonyLib;
using Tools.Level.Interactables;

namespace MoreItems.DamageRemovalOnce
{
    [HarmonyPatch(typeof(Entity), "KillInstanteneously")]
    class Penitent_Death_Patch
    {
        public static void Postfix(Entity __instance)
        {
            if (__instance is Penitent)
            {
                Main.Items.Log("RB503: Regain damage removal (death)");
                DamageRemovalEffect.RegainDamageRemoval();
            }
        }
    }

    [HarmonyPatch(typeof(PrieDieu), "OnUse")]
    class PrieDieu_Use_Patch
    {
        public static void Prefix()
        {
            Main.Items.Log("RB503: Regain damage removal (priedieu)");
            DamageRemovalEffect.RegainDamageRemoval();
        }
    }

    [HarmonyPatch(typeof(PenitentDamageArea), "TakeDamage")]
    public class DamageArea_Patch
    {
        public static void Prefix(ref Hit hit)
        {
            if (DamageRemovalEffect.Active && DamageRemovalEffect.WillRemoveDamage)
            {
                Main.Items.Log("RB503: Removing all damage");
                hit.DamageAmount = 0;
                DamageRemovalEffect.UseDamageRemoval();
                // Play vfx or sfx
            }
        }
    }
}
