using HarmonyLib;
using System.Collections;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using PiFix.Configuration;
using IPA.Loader;
using IPALogger = IPA.Logging.Logger;
using System;

namespace PiFix
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static PluginConfig Config { get; private set; }
        internal static IPALogger Logger { get; private set; }
        internal static Harmony harmony { get; private set; }
        private const string Resource_Settings_Path = "PiFix.UI.Settings.bsml";
        private bool BSMLPresent => PluginManager.GetPluginFromId("BeatSaberMarkupLanguage") != null
            && PluginManager.GetDisabledPluginFromId("BeatSaberMarkupLanguage") == null;
        private bool SettingsMenuCreated { get; set; }
        [Init]
        public Plugin(IPALogger logger, Config conf, PluginMetadata pluginMetadata)
        {
            if (harmony == null)
                harmony = new Harmony("com.guppyexpress.beatsaber.PiFix");
            Logger = logger;
            Config = conf.Generated<PluginConfig>();
        }
        [OnEnable]
        public void OnEnable()
        {
            Logger.Debug($"PiFix enabled for headset '{Config.PiMaxType}'");
            if (!SettingsMenuCreated)
                CreateSettingsMenu();
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnDisable()
        {
            Logger.Debug($"PiFix disabled");
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
            harmony.UnpatchSelf();
        }

        private void CreateSettingsMenu()
        {
            try
            {
                if (BSMLPresent)
                {
                    Logger.Debug("Creating settings menu");
                    BeatSaberMarkupLanguage.Settings.BSMLSettings.instance.AddSettingsMenu("PiFix", Resource_Settings_Path, Config);
                    SettingsMenuCreated = true;
                }
                else
                {
                    Logger.Debug("BeatSaberMarkupLanguage not found, skipping settings menu");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error creating settings menu: {ex.Message}");
                Logger.Debug(ex.StackTrace);
            }
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            if (Config.DisableLighting)
                SharedCoroutineStarter.instance.StartCoroutine(DisablePrePassLights());

            SharedCoroutineStarter.instance.StartCoroutine(SwapSpriteTextShader());
        }

        private IEnumerator DisablePrePassLights()
        {
            yield return new WaitForSeconds(0.1f);
            Resources.FindObjectsOfTypeAll<BloomPrePassLight>()?.ToList().ForEach(t =>
            {
                var tube = t.GetComponentInChildren<TubeBloomPrePassLight>();
                if (tube)
                    tube.enabled = false;
            });
        }
        bool materialFound = true;
        private IEnumerator SwapSpriteTextShader()
        {
            yield return new WaitForSeconds(0.1f);
            string materialName = "UINoGlow";
            Material material = Resources.FindObjectsOfTypeAll<Material>().Where(m => m.name == materialName).FirstOrDefault();
            if (material != null)
            {
                if (!materialFound)
                {
                    Logger.Debug($"Using material '{material.name}'");
                }
                materialFound = true;
                Resources.FindObjectsOfTypeAll<UnityEngine.UI.Image>()?.ToList().ForEach(t =>
                {
                    var mat = Material.Instantiate(material);
                    mat.color = t.material.color.ColorWithAlpha(t.material.color.a == 0 ? 0.7f : t.material.color.a);
                    t.material = mat;
                });

                Resources.FindObjectsOfTypeAll<TMP_Text>()?.ToList().ForEach(t =>
                {
                    var mat = Material.Instantiate(material);
                    mat.color = t.material.color.ColorWithAlpha(t.material.color.a == 0 ? 0.7f : t.material.color.a);
                    t.material = mat;
                });
            }
            else
            {
                if (materialFound)
                    Logger.Debug($"Could not find Material '{materialName}'");
                materialFound = false;
            }
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            // if (arg0.name == "MenuCore") ;

        }
    }
}
