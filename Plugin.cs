﻿using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using mod1.Items.Natural;

namespace mod1
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // Initialize custom prefabs
            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            
        }

        private void InitializePrefabs()
        {
            Coal.Register();
            Silicon.Register();
            Carbon_Monoxide.Register();
            Carbon_Dioxide.Register();
            Graphite.Register();
        }
    }
}