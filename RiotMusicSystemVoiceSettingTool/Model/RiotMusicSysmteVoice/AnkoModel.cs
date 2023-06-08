using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotMusicSystemVoiceSettingTool.Model.RiotMusicSysmteVoice
{
    internal class AnkoModel : ActorBaseModel
    {
        public AnkoModel()
        {
            Actor = ActorType.Anko;
            FullName = "朝倉杏子";
            ShortName = "杏子";
            StoreUrlPostfix = "2305-bw-system-voice-anko";
            DefaultRegistryKey = "anko";
        }
    }
}
