using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace RainbowIce
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public GameObject loader;

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }
        void OnGameInitialized(object sender, EventArgs e)
        {
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("RainbowIce.Assets.loader");
            AssetBundle rainbow = AssetBundle.LoadFromStream(str);
            GameObject road = rainbow.LoadAsset<GameObject>("loader");
            


            GameObject.Find("Level/mountain/Geometry/mountainsideice").GetComponent<Renderer>().material = road.GetComponent<Renderer>().material;

        }
    }
}
