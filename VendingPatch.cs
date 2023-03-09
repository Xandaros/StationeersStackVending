
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Items;
using Assets.Scripts.Objects.Motherboards;
using HarmonyLib;

namespace StationeersStackVending
{
    // [HarmonyPatch(typeof(VendingMachine), "TryProcessImport")]
    // public class VendingPatch {
    //     [HarmonyPrefix]
    //     public static bool Prefix(ref VendingMachine __instance) {
    //         Plugin.Log("TryProcessImport called");
    //         if (__instance.ImportingThing != null) {
    //             for (int i = 0; i < __instance.Slots.Count; i++) {
    //                 Slot slot = __instance.Slots[i];
    //                 if (!slot.IsInteractable) {
    //                     if (slot.Occupant != null) {
    //                         if (Slot.CanMerge(__instance.ImportingThing, slot)) {
    //                             if (__instance.ImportingThing is Stackable importing) {
    //                                 if (slot.Occupant is Stackable occupant) {
    //                                     OnServer.Merge(occupant, importing);
    //                                     if (occupant.Quantity <= 0) {
    //                                         return false;
    //                                     }
    //                                 }
    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //         }
    //         return true;
    //     }
    // }
    //
    [HarmonyPatch(typeof(VendingMachine))]
    [HarmonyPatch(nameof(VendingMachine.GetLogicValue))]
    public class VendingPatch {
        public static bool Prefix(ref double __result, LogicType logicType) {
            if (logicType == LogicType.ExportCount) {
                __result = 1337f;
                return false;
            }
            return true;
        }
    }
}
