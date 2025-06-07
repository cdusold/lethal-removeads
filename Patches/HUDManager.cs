using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace RemoveAds.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    internal class HUDManagerPatch
    {

        [HarmonyPatch("BeginDisplayAd")]
        [HarmonyPrefix]
        private static bool BeginDisplayAd()
        {
            Plugin.logger.LogInfo("Skipping the display of the ad. You're welcome!");
            return false;
        }

    }
    
}