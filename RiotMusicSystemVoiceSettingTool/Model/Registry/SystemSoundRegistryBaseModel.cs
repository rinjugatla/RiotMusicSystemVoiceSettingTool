using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotMusicSystemVoiceSettingTool.Model.Registry
{
    internal class SystemSoundRegistryBaseModel
    {
        /// <summary>初期値</summary>
        public RegistryModel Default { get; private set; }
        /// <summary>現在値</summary>
        public RegistryModel Current { get; private set; }
        /// <summary>RiotMusic</summary>
        public RegistryModel RiotMusicSystemSound { get; private set; }

        public enum SystemSoundRegistryType
        {
            Default,
            Current,
            RiotMusic,
            Unknown
        }

        public void Set(SystemSoundRegistryType type, RegistryModel model)
        {
            switch (type)
            {
                case SystemSoundRegistryType.Default:
                    Default = model; break;
                case SystemSoundRegistryType.Current:
                    Current = model; break;
                case SystemSoundRegistryType.RiotMusic:
                    RiotMusicSystemSound = model; break;
                default:
                    break;
            }
        }
    }
}
