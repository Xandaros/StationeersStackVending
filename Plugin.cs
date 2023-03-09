using System;
using System.Reflection;
using Assets.Scripts;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Items;
using BepInEx;
using HarmonyLib;
using UnityEngine;

// protected virtual void TryProcessImport()
// {
// 	if (ImportingThing != null)
// 	{
// 		for (int i = 0; i < Slots.Count; i++)
// 		{
// 			Slot slot = Slots[i];
// 			if (!slot.IsInteractable)
// 			{
// 				if (!(slot.Occupant != null))
// 				{
// 					OnServer.MoveToSlot(ImportingThing, slot);
// 					break;
// 				}
// 				if (i == Slots.Count - 1)
// 				{
// 					PlayNetworkSound(FabricatorBase.ImportErrorHash, base.InteractOnOff.Collider.transform.localPosition);
// 				}
// 			}
// 		}
// 	}
// 	OnServer.Interact(base.InteractImport, 0);
// }

namespace StationeersStackVending
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGuid = "io.inp.stationeers.stackvending";
        public const string pluginName = "StackVending";
        public const string pluginVersion = "0.1.0";
        private static Harmony _h;
        public static void Log(string line) {
            Debug.Log("[StackVending]: " + line);
        }
        private void Awake()
        {
            try {
                _h = new Harmony("io.inp.stationeers.stackvending");
                _h.PatchAll();
                Log("Patch succeeded");
            } catch (Exception e) {
                Log("Path failed");
                Log(e.ToString());
            }
        }

        private void OnDestroy()
        {
            _h.UnpatchSelf();
        }
    }
}
