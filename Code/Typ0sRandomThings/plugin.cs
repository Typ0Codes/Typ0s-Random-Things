using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System;

using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using UnityEngine;

namespace Typ0sRandomThings
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]

    public class Plugin : BaseUnityPlugin
    {

        const string GUID = "SLDTyp0.Typ0sRandomThings";
        const string NAME = "Typ0's Random Things";
        const string VERSION = "2.0.1";

        public static Plugin instance;
        void Awake()
        {
            instance = this;

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "typ0sassets");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            Item willhat = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/Typ0's Random Things/Items/Wills Hat/Wills Hat.asset");
            Item walkman = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/Typ0's Random Things/Items/Walkman/walkman.asset");
            Item waterbottle = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/Typ0's Random Things/Items/water bottle/Waterbottle.asset");
            Item fireextinguisher = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/Typ0's Random Things/Items/FireExtinguisher/firextinguisher.asset");


            Logger.LogInfo("Loading Typ0's Random Things");

            NetworkPrefabs.RegisterNetworkPrefab(willhat.spawnPrefab);
            Utilities.FixMixerGroups(willhat.spawnPrefab);
            Items.RegisterScrap(willhat, 40, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded Will's Entire Personality Into The Game");

            NetworkPrefabs.RegisterNetworkPrefab(waterbottle.spawnPrefab);
            Utilities.FixMixerGroups(waterbottle.spawnPrefab);
            Items.RegisterScrap(waterbottle, 75, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded Waterbottle");

            NetworkPrefabs.RegisterNetworkPrefab(fireextinguisher.spawnPrefab);
            Utilities.FixMixerGroups(fireextinguisher.spawnPrefab);
            Items.RegisterScrap(fireextinguisher, 75, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded Fire extinguisher");

            NetworkPrefabs.RegisterNetworkPrefab(walkman.spawnPrefab);
            Utilities.FixMixerGroups(walkman.spawnPrefab);
            Items.RegisterScrap(walkman, 65, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded walkman");

            Logger.LogInfo("Loaded All Items!");

            Logger.LogInfo("Finished Loading Typ0's Random Things");
        }
    }
}

