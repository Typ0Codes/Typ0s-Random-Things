using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System;

using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using UnityEngine;
using System.Collections;

namespace Typ0sRandomThings
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]

    public class Plugin : BaseUnityPlugin
    {

        const string GUID = "SLDTyp0.Typ0sRandomThings";
        const string NAME = "Typ0's Random Things";
        const string VERSION = "2.2.3";

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
            Item moonshine = bundle.LoadAsset<Item>("Assets/LethalCompany/Mods/Typ0's Random Things/Items/Moonshine/Moonshine.asset");


            Logger.LogInfo("Loading Typ0's Random Things");

            NetworkPrefabs.RegisterNetworkPrefab(willhat.spawnPrefab);
            Utilities.FixMixerGroups(willhat.spawnPrefab);
            Items.RegisterScrap(willhat, 15, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded Will's Entire Personality Into The Game");

            

            NetworkPrefabs.RegisterNetworkPrefab(waterbottle.spawnPrefab);
            Utilities.FixMixerGroups(waterbottle.spawnPrefab);
            Items.RegisterScrap(waterbottle, 40, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded Waterbottle");

             

            NetworkPrefabs.RegisterNetworkPrefab(fireextinguisher.spawnPrefab);
            Utilities.FixMixerGroups(fireextinguisher.spawnPrefab);
            Items.RegisterScrap(fireextinguisher, 35, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded Fire extinguisher");

             

            NetworkPrefabs.RegisterNetworkPrefab(walkman.spawnPrefab);
            Utilities.FixMixerGroups(walkman.spawnPrefab);
            Items.RegisterScrap(walkman, 30, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded walkman");

             

            NetworkPrefabs.RegisterNetworkPrefab(moonshine.spawnPrefab);
            Utilities.FixMixerGroups(moonshine.spawnPrefab);
            Items.RegisterScrap(moonshine, 30, Levels.LevelTypes.All);
            Logger.LogInfo("Loaded moonshine");

             

            Logger.LogInfo("Loaded All Items!");

             

            Logger.LogInfo("Finished Loading Typ0's Random Things");
        }
    }
}

