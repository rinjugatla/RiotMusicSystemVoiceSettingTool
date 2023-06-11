using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiotMusicSystemVoiceSettingTool.Model.SystemSoundModel;

namespace RiotMusicSystemVoiceSettingTool.Model.Registry
{
    internal class WindwsSystemSoundRegistryModel : SystemSoundRegistryBaseModel
    {
        public WindowsSoundType SoundType { get; private set; } 

        public WindwsSystemSoundRegistryModel(WindowsSoundType type)
        {
            SoundType = type;
        }
    }
}
