using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BeatSaberMarkupLanguage.Attributes;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace PiFix.Configuration
{
    public enum PimaxType
    {

        None,
        [Description("5k")]
        FiveK, 
        [Description("8k")]
        EightK,
        [Description("12k")]
        TwelveK,
        [Description("Crystal")]
        Crystal,
        [Description("Valve Index")]
        ValveIndex,
    }

    internal class PluginConfig
    {

        [UseConverter(typeof(EnumConverter<
            
            
            
            
            
            >))]
        public virtual PimaxType PimaxType { get; set; } = PimaxType.None;
        public virtual bool DisableLighting { get; set; } = false;

        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
            PimaxType = other.PimaxType;
        }

        /// <summary>
        /// List of possible options for BSML settings view.
        /// </summary>
        [Ignore]
        public List<object> PimaxTypes = new List<object>() 
        { 
            PimaxType.None,
            PimaxType.FiveK,
            PimaxType.EightK,
            PimaxType.TwelveK,
            PimaxType.ValveIndex
        };

    }
}
