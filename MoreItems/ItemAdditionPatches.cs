using Framework.Dialog;
using Framework.Managers;
using HarmonyLib;
using ModdingAPI;
using System.Collections.Generic;
using Tools.Playmaker2.Action;

namespace MoreItems
{
    [HarmonyPatch(typeof(DialogStart), nameof(DialogStart.DialogEnded))]
    public class DialogStart_Patch
    {
        public static void Prefix(string id)
        {
            // Amanecida core heart from Deogracias
            if (id == "DLG_01101")
            {
                if (!Core.Events.GetFlag("DEOSGRACIAS_SANTOS_DONE"))
                    ItemModder.AddAndDisplayItem("HE501");
            }
        }
    }

    [HarmonyPatch(typeof(DialogManager), nameof(DialogManager.StartConversation))]
    public class DialogManager_Patch
    {
        public static void Prefix(string conversiationId, Dictionary<string, DialogObject> ___allDialogs)
        {
            Main.Items.Log("Starting dialog: " + conversiationId);

            // Amanecida core heart from Deogracias
            if (conversiationId == "DLG_01101")
            {
                DialogObject current = ___allDialogs[conversiationId];
                while (current.dialogLines.Count > 3)
                    current.dialogLines.RemoveAt(current.dialogLines.Count - 1);

                if (!Core.Events.GetFlag("DEOSGRACIAS_SANTOS_DONE"))
                {
                    current.dialogLines.Add(Main.Items.Localize("deog01"));
                    current.dialogLines.Add(Main.Items.Localize("deog02"));
                    current.dialogLines.Add(Main.Items.Localize("deog03"));
                }
            }
        }
    }
}
