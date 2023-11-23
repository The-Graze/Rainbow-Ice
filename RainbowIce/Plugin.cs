using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace RainbowIce
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public GameObject loader;
        Stream str;
        AssetBundle rainbow;
        public static Material mat;
        void Start()
        {
            Events.GameInitialized += OnGameInitialized;
        }
        void OnGameInitialized(object sender, EventArgs e)
        {
            str = Assembly.GetExecutingAssembly().GetManifestResourceStream("RainbowIce.Assets.loader");
            rainbow = AssetBundle.LoadFromStream(str);
            GameObject road = rainbow.LoadAsset<GameObject>("loader");
            str.Close();
            mat = road.GetComponent<Renderer>().material;
            GameObject.Find("LocalObjects_Prefab").AddComponent<MountainLooker>();
            rainbow.Unload(false);
        }
    }
    class MountainLooker : MonoBehaviour 
    {
        void Update()
        {
            if (transform.GetChild(9).gameObject.activeSelf)
            {
                transform.FindChildRecursive("iceground (combined mesh created by EdMeshCombinerSceneProcessor)").GetComponent<Renderer>().material = Plugin.mat;
                Destroy(this);
                return;
            }
            else
            {
                return;
            }
        }
    }
}
