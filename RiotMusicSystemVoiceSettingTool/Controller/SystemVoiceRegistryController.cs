using Microsoft.Win32;
using RiotMusicSystemVoiceSettingTool.Model.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiotMusicSystemVoiceSettingTool.Model.SystemSoundModel;

namespace RiotMusicSystemVoiceSettingTool.Controller
{
    internal class SystemVoiceRegistryController
    {
        /// <summary>サウンド設定の項目パス</summary>
        private const string SystemVoiceItemNameBasePath = @"AppEvents\Schemes\Names\";
        /// <summary>サウンド設定に登録済みの項目</summary>
        private List<string> _SystemVoiceRegisterdItemNames = new List<string>();

        private SystemSoundRegistriesModel SoundRegistries = new SystemSoundRegistriesModel();

        /// <summary>サウンド設定に登録済みの項目</summary>
        public List<string> SystemVoiceRegisterdItemNames
        {
            get { return new List<string>(_SystemVoiceRegisterdItemNames); }
            private set { _SystemVoiceRegisterdItemNames = value; }
        }

        public void ReadRegistrySetting()
        {
            SoundRegistries.ReadRegistrySeeting();
        }

        ///// <summary>サウンド設定に登録済みの項目を取得</summary>
        //public void GetRegisterdItemNames()
        //{
        //    RegistryKey registerdItemNameKey = Registry.CurrentUser.OpenSubKey(SystemVoiceItemNameBasePath, false);
        //    _SystemVoiceRegisterdItemNames = registerdItemNameKey.GetSubKeyNames().ToList();
        //}

        //public List<string> GetRegisterdSoundKeys()
        //{
        //    RegistryKey registerdItemNameKey = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\.Default", false);
        //    var result = registerdItemNameKey.GetSubKeyNames().ToList();
        //    return result;
        //}

        //public Dictionary<string, string> GetRegistedDefaultSound()
        //{
        //    var result = new Dictionary<string, string>();

        //    string basePath = @"AppEvents\Schemes\Apps\Explorer";
        //    RegistryKey registerdItemNameKey = Registry.CurrentUser.OpenSubKey(basePath, false);
        //    var keys = registerdItemNameKey.GetSubKeyNames();
        //    foreach (var key in keys)
        //    {
        //        using (var subkey = Registry.CurrentUser.OpenSubKey($@"{basePath}\{key}\.Current", false))
        //        {
        //            var value = subkey.GetValue(DEFAULT_KEY) as string;
        //            result.Add(key, value);
        //        }
        //    }

        //    return result;
        //}
    }
}
