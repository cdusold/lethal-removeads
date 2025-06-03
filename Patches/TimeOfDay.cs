using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace RemoveAds.Patches
{
    [HarmonyPatch(typeof(TimeOfDay))]
    internal class TimeOfDayPatch
    {

        [HarmonyPatch("SyncNewProfitQuotaClientRpc")]
        [HarmonyPostfix]
        private static void SetNewQuotaFulfiledClient(ref int ___quotaFulfilled, ref int ___profitQuota)
        {
            TimeOfDay.Instance.hasShownAdThisQuota = true;
        }

        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void StartPatch(ref TimeOfDay __instance)
        {
            if (__instance == null)
            {
                return;
            }
            __instance.hasShownAdThisQuota = true;
        }

    }
}