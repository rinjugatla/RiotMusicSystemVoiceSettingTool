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
using System.Windows;
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
        /// <param name="directoryPath">システムボイス配置フォルダ</param>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        /// <param name="model">ボイスモデル</param>
        public void RegistSystemVoice(string directoryPath, string soundItemName, ActorBaseModel model)
        {
            try
            {
                RegistActorName(soundItemName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"サウンド項目名の登録に失敗しました。\r\n詳細: {ex.Message}", "サウンド項目名の登録", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RegistRegistryKeys(soundItemName);
            RegistSystemVoicePaths(directoryPath, soundItemName, model);
        }

        /// <summary>サウンド選択項目を登録</summary>
        private void RegistActorName(string soundItemName)
        {
            try
            {
                string registryPath = $@"AppEvents\Schemes\Names\{soundItemName}";
                using (var key = Registry.CurrentUser.CreateSubKey(registryPath))
                {
                    key.SetValue(null, soundItemName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>レジストリキーを作成</summary>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        private void RegistRegistryKeys(string soundItemName)
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

            if (errors.Any())
            {
                string message = string.Join("\r\n", errors);
                MessageBox.Show($"以下のレジストリキーの登録に失敗しました。\r\n{message}", "レジストリキーの登録",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>システムボイスをレジストリに登録</summary>
        /// <param name="directoryPath">システムボイス配置フォルダ</param>
        /// <param name="soundItemName">サウンド選択項目名(mionaなど)</param>
        /// <param name="model">ボイスモデル</param>
        private void RegistSystemVoicePaths(string directoryPath, string soundItemName, ActorBaseModel model)
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

            if (errors.Any())
            {
                string message = string.Join("\n", errors);
                MessageBox.Show($"以下の音声ファイルパスの登録に失敗しました。\r\n{message}", "音声ファイルパスの登録", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
