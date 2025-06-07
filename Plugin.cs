using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using RemoveAds.Patches;
using RemoveAds.Compat;
using HarmonyLib;

namespace RemoveAds
{
    [BepInPlugin("com.github.cdusold.LethalRemoveAds", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("BMX.LobbyCompatibility", BepInDependency.DependencyFlags.SoftDependency)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("cdusold.LethalRemoveAds");

        private static Plugin Instance;

        public static ManualLogSource logger;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            logger = Logger;
            Logger.LogInfo("Mod cdusold.LethalRemoveAds is loaded!");

            if (Chainloader.PluginInfos.ContainsKey("BMX.LobbyCompatibility"))
            {
                LobbyCompatibilityManager.Init();
            }
            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(HUDManagerPatch));
        }
    }
}
