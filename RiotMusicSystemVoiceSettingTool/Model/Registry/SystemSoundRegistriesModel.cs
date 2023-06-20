using Win32 = Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiotMusicSystemVoiceSettingTool.Model.SystemSoundModel;
using static RiotMusicSystemVoiceSettingTool.Model.Registry.SystemSoundRegistryBaseModel;

namespace RiotMusicSystemVoiceSettingTool.Model.Registry
{
    internal class SystemSoundRegistriesModel
    {
        /// <summary>デフォルトキー</summary>
        private const string DEFAULT_KEY = null;
        /// <summary></summary>
        private Dictionary<WindowsSoundType, WindwsSystemSoundRegistryModel> WindowsSoundRegistries = new Dictionary<WindowsSoundType, WindwsSystemSoundRegistryModel>();
        /// <summary></summary>
        private Dictionary<ExplorerSoundType, ExplorerSystemSoundRegistryModel> ExplorerSoundRegistries = new Dictionary<ExplorerSoundType, ExplorerSystemSoundRegistryModel>();

        public void ReadRegistrySeeting()
        {
            foreach (WindowsSoundType type in Enum.GetValues(typeof(WindowsSoundType)))
            {
                ReadRegistrySetting(type);
            }

            foreach (ExplorerSoundType type in Enum.GetValues(typeof(ExplorerSoundType)))
            {
                ReadRegistrySetting(type);
            }
        }

        /// <summary>現在のサウンド設定を設定</summary>
        private void ReadRegistrySetting(WindowsSoundType type)
        {
            if (WindowsSoundRegistries.ContainsKey(type)) { WindowsSoundRegistries.Remove(type); }

            var rootPath = RegistryPath(type);
            var key = Win32.Registry.CurrentUser.OpenSubKey(rootPath, false);
            if(key == null) { return; }

            var model = new WindwsSystemSoundRegistryModel(type);
            foreach (var subName in key.GetSubKeyNames())
            {
                var subPath = $@"{rootPath}\{subName}";
                SystemSoundRegistryType keyType = SystemSoundRegistryType.Unknown;
                switch (subName)
                {
                    case ".Default":
                        keyType = SystemSoundRegistryType.Default; break;
                    case ".Current":
                        keyType = SystemSoundRegistryType.Current; break;
                    default:
                        continue;
                }
                var subKey = Win32.Registry.CurrentUser.OpenSubKey(subPath, false);
                var value = subKey.GetValue(DEFAULT_KEY) as string;
                var registry = new RegistryModel(subPath, DEFAULT_KEY, value);
                model.Set(keyType, registry);
            }
            WindowsSoundRegistries.Add(type, model);
        }

        /// <summary>現在のサウンド設定を設定</summary>
        private void ReadRegistrySetting(ExplorerSoundType type)
        {
            if (ExplorerSoundRegistries.ContainsKey(type)) { ExplorerSoundRegistries.Remove(type); }

            var rootPath = RegistryPath(type);
            var key = Win32.Registry.CurrentUser.OpenSubKey(rootPath, false);
            if (key == null) { return; }

            var model = new ExplorerSystemSoundRegistryModel(type);
            foreach (var subName in key.GetSubKeyNames())
            {
                var subPath = $@"{rootPath}\{subName}";
                SystemSoundRegistryType keyType = SystemSoundRegistryType.Unknown;
                switch (subName)
                {
                    case ".Default":
                        keyType = SystemSoundRegistryType.Default; break;
                    case ".Current":
                        keyType = SystemSoundRegistryType.Current; break;
                    default:
                        continue;
                }
                var subKey = Win32.Registry.CurrentUser.OpenSubKey(subPath, false);
                var value = subKey.GetValue(DEFAULT_KEY) as string;
                var registry = new RegistryModel(subPath, DEFAULT_KEY, value);
                model.Set(keyType, registry);
            }
            ExplorerSoundRegistries.Add(type, model);
        }

        /// <summary>登録済みのレジストリ設定を取得</summary>
        public RegistryModel GetRegistrySetting(WindowsSoundType type, SystemSoundRegistryType registryType)
        {
            if (!WindowsSoundRegistries.ContainsKey(type)) { return null; }

            switch (registryType)
            {
                case SystemSoundRegistryType.Default:
                    return WindowsSoundRegistries[type].Default;
                case SystemSoundRegistryType.Current:
                    return WindowsSoundRegistries[type].Current;
                default:
                    return null;
            }
        }

        /// <summary>登録済みのレジストリ設定を取得</summary>
        public RegistryModel GetRegistrySetting(ExplorerSoundType type, SystemSoundRegistryType registryType)
        {
            if (!ExplorerSoundRegistries.ContainsKey(type)) { return null; }

            switch (registryType)
            {
                case SystemSoundRegistryType.Default:
                    return ExplorerSoundRegistries[type].Default;
                case SystemSoundRegistryType.Current:
                    return ExplorerSoundRegistries[type].Current;
                default:
                    return null;
            }
        }
    }
}
