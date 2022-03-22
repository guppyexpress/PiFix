using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Settings;
using IPA.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaxLightFixer
{
    class Settings
    {
        public static void OnLoad()
        {
            var menu = SettingsUI.CreateSubMenu("Pimax Light Fixer");
            var disableLighting = menu.AddBool("Disable Lighting", "When enabled, the problem light components are completely destroyed instead of being repositioned.");
            disableLighting.GetValue += () => { return Config.DisableLighting; };
            disableLighting.SetValue += (value) => { Config.DisableLighting = value; };
        }
    }
}
