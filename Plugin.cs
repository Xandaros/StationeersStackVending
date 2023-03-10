using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace StationeersStackVending
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string pluginGuid = "io.inp.stationeers.stackvending";
        public const string pluginName = "StackVending";
        public const string pluginVersion = "1.0.0";
        private static Harmony _h;
        public static void Log(string line) {
            Debug.Log("[StackVending]: " + line);
        }
        private void Awake()
        {
            try {
                _h = new Harmony(pluginGuid);
                _h.PatchAll();
                Log("Patch succeeded");
            } catch (Exception e) {
                Log("Path failed");
                Log(e.ToString());
            }
        }
    }
}
