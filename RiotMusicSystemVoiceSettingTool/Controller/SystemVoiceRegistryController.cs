using Microsoft.Win32;
using RiotMusicSystemVoiceSettingTool.Model;
using RiotMusicSystemVoiceSettingTool.Model.Registry;
using RiotMusicSystemVoiceSettingTool.Model.RiotMusicSysmteVoice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RiotMusicSystemVoiceSettingTool.Model.Registry.SystemSoundRegistryBaseModel;
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

        /// <summary>システムボイスをレジストリに登録</summary>
        /// <param name="useDefaultSound"></param>
        /// <param name="directoryPath">システムボイス配置フォルダ</param>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        /// <param name="model">ボイスモデル</param>
        /// <returns>エラー</returns>
        public string RegistSystemVoice(bool useDefaultSound, string directoryPath, 
                                      string soundItemName, ActorBaseModel model)
        {
            List<string> errors = new List<string>();
            string actorError =  RegistActorName(soundItemName);
            errors.Add(actorError);

            string registKeyError = RegistRegistryKeys(soundItemName);
            errors.Add(registKeyError);

            if (useDefaultSound)
            {
                string registDefaultError = RegistDefaultSystemSoundPath(soundItemName);
                errors.Add(registDefaultError);
            }

            string registVoiceError = RegistSystemVoicePaths(directoryPath, soundItemName, model);
            errors.Add(registVoiceError);

            var result = string.Join("\r\n----------\r\n", errors.Where(e => e != null));
            return result;
        }

        /// <summary>サウンド選択項目を登録</summary>
        private string RegistActorName(string soundItemName)
        {
            try
            {
                string registryPath = $@"AppEvents\Schemes\Names\{soundItemName}";
                using (var key = Registry.CurrentUser.CreateSubKey(registryPath))
                {
                    key.SetValue(null, soundItemName);
                }
            }
            catch (Exception ex)
            {
                return $"サウンド選択項目の登録に失敗しました。{ex.Message}";
            }

            return null;
        }

        /// <summary>デフォルトサウンドパスを登録</summary>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        private string RegistDefaultSystemSoundPath(string soundItemName)
        {
            List<string> errors = new List<string>();
            foreach (WindowsSoundType type in Enum.GetValues(typeof(WindowsSoundType)))
            {
                try
                {
                    var setting = SoundRegistries.GetRegistrySetting(type, SystemSoundRegistryType.Default);
                    if (setting == null) { continue; }

                    var filepath = setting.Value;
                    if (!File.Exists(filepath)) { continue; }

                    string registryPath = Path.Combine(RegistryPath(type), soundItemName);
                    using (var key = Registry.CurrentUser.CreateSubKey(registryPath))
                    {
                        key.SetValue(null, filepath);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{type} {ex.Message}");
                }
            }

            foreach (ExplorerSoundType type in Enum.GetValues(typeof(ExplorerSoundType)))
            {
                try
                {
                    var setting = SoundRegistries.GetRegistrySetting(type, SystemSoundRegistryType.Default);
                    if (setting == null) { continue; }

                    var filepath = setting.Value;
                    if (!File.Exists(filepath)) { continue; }

                    string registryPath = Path.Combine(RegistryPath(type), soundItemName);
                    using (var key = Registry.CurrentUser.CreateSubKey(registryPath))
                    {
                        key.SetValue(null, filepath);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{type} {ex.Message}");
                }
            }

            if (!errors.Any()) { return null; }

            var message = string.Join("\r\n", errors);
            var result = $"以下のデフォルトサウンドの設定に失敗しました。\r\n{message}";
            return result;
        }

        /// <summary>レジストリキーを作成</summary>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        private string RegistRegistryKeys(string soundItemName)
        {
            List<string> errors = new List<string>();
            foreach (WindowsSoundType type in Enum.GetValues(typeof(WindowsSoundType)))
            {
                try
                {
                    string registryPath = Path.Combine(RegistryPath(type), soundItemName);
                    using (var key = Registry.CurrentUser.CreateSubKey(registryPath)) { };
                }
                catch (Exception ex)
                {
                    errors.Add($"{type} {ex.Message}");
                }
            }

            foreach (ExplorerSoundType type in Enum.GetValues(typeof(ExplorerSoundType)))
            {
                try
                {
                    string registryPath = Path.Combine(RegistryPath(type), soundItemName);
                    using (var key = Registry.CurrentUser.CreateSubKey(registryPath)) { };
                }
                catch (Exception ex)
                {
                    errors.Add($"{type} {ex.Message}");
                }
            }

            if (!errors.Any()) { return null; }

            var message = string.Join("\r\n", errors);
            var result = $"以下のレジストリキーの登録に失敗しました。\r\n{message}";
            return result;
        }

        /// <summary>システムボイスをレジストリに登録</summary>
        /// <param name="directoryPath">システムボイス配置フォルダ</param>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        /// <param name="model">ボイスモデル</param>
        private string RegistSystemVoicePaths(string directoryPath, string soundItemName, ActorBaseModel model)
        {
            List<string> errors = new List<string>();
            foreach (WindowsSoundType type in model.ExistsVoiceWindowsSoundType())
            {
                string registryPath = Path.Combine(RegistryPath(type), soundItemName);
                string filepath = Path.Combine(directoryPath, model.VoiceFileName(type));
                if (!File.Exists(filepath)) { continue; }

                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey(registryPath, true))
                    {
                        key.SetValue(null, filepath);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{type} {ex.Message}");
                }
            }

            foreach (ExplorerSoundType type in model.ExistsVoiceExplorerSoundType())
            {
                string registryPath = Path.Combine(RegistryPath(type), soundItemName);
                string filepath = Path.Combine(directoryPath, model.VoiceFileName(type));
                if (!File.Exists(filepath)) { continue; }

                try
                {
                    using (var key = Registry.CurrentUser.OpenSubKey(registryPath, true))
                    {
                        key.SetValue(null, filepath);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"{type} {ex.Message}");
                }
            }

            if (!errors.Any()) { return null; }

            var message = string.Join("\r\n", errors);
            var result = $"以下のボイスファイルパスの登録に失敗しました。\r\n{message}";
            return result;
        }
    }
}
