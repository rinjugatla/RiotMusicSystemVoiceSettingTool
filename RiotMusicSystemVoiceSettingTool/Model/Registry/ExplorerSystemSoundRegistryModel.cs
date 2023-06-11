using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiotMusicSystemVoiceSettingTool.Model.SystemSoundModel;

namespace RiotMusicSystemVoiceSettingTool.Model.Registry
{
    internal class ExplorerSystemSoundRegistryModel : SystemSoundRegistryBaseModel
    {
        public ExplorerSoundType SoundType { get; private set; }

        public ExplorerSystemSoundRegistryModel(ExplorerSoundType type)
        {
            SoundType = type;
        }
    }
}
