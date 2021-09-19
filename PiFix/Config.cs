using BeatSaberAPI;
using IPA.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiFix
{
    class Config
    {
        public static bool DisableLighting
        {
            get
            {
                return ModPrefs.GetBool("PimaxLightFixer", "DisableLighting", false, true);
            }
            set
            {
                ModPrefs.SetBool("PimaxLightFixer", "DisableLighting", value);
            }
        }
    }
}
