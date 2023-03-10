using System.Collections.Generic;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Items;
using HarmonyLib;

namespace StationeersStackVending
{
    [HarmonyPatch(typeof(VendingMachine), "TryProcessImport")]
    public class VendingPatch {
        [HarmonyPrefix]
        public static bool Prefix(DynamicThing ___ImportingThing, List<Slot> ___Slots) {
            var importingThing = ___ImportingThing;
            if (importingThing != null) {
                var slots = ___Slots;
                for (int i = 0; i < slots.Count; i++) {
                    Slot slot = slots[i];
                    if (!slot.IsInteractable) {
                        if (slot.Occupant != null) {
                            if (Slot.CanMerge(importingThing, slot)) {
                                if (importingThing is Stackable importing) {
                                    if (slot.Occupant is Stackable occupant) {
                                        OnServer.Merge(occupant, importing);
                                        if (occupant.Quantity <= 0) {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }

}
