using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotMusicSystemVoiceSettingTool.Model.Registry
{
    internal class RegistryModel
    {
        /// <summary>パス</summary>
        public string Path { get; private set; }
        /// <summary>名前</summary>
        public string Name { get; private set; }
        /// <summary>値</summary>
        public string Value { get; private set; }

        public RegistryModel(string path, string name, string value)
        {
            Path = path;
            Name = name;
            Value = value;
        }
    }
}
