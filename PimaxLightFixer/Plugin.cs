using HarmonyLib;
using BeatSaberAPI;
using System.Collections;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPA;
using IPA.Config;
using PiFix.Configuration;

namespace PimaxLightFixer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static PluginConfig Config { get; private set; }
        internal static Harmony harmony { get; private set; }
        [OnEnable]
        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            if (harmony == null)
                harmony = new Harmony("com.guppyexpress.beatsaber.PiFix");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnDisable]
        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
            harmony.UnpatchSelf();
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

        private IEnumerator SwapSpriteTextShader()
        {
            yield return new WaitForSeconds(0.1f);

            Material material = Resources.FindObjectsOfTypeAll<Material>().Where(m => m.name == "UINoGlow").FirstOrDefault();

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

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            // if (arg0.name == "MenuCore") ;

        }
    }
}
