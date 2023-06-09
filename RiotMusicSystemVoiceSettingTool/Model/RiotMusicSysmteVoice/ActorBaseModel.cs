﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RiotMusicSystemVoiceSettingTool.Model.SystemSoundModel;

namespace RiotMusicSystemVoiceSettingTool.Model.RiotMusicSysmteVoice
{
    internal class ActorBaseModel
    {
        /// <summary>フルネーム</summary>
        public string FullName { get; protected set; }
        /// <summary>ファイル名用の短い名前</summary>
        public string ShortName { get; protected set; }
        /// <summary>販売URL接尾語</summary>
        protected string StoreUrlPostfix { get; set; }
        /// <summary>販売URL</summary>
        public string StoreUrl
        {
            get
            {
                string prefix = "https://riotmusic.store/collections/2305-bw-system-voice/products/";
                string url = prefix + StoreUrlPostfix;
                return url;
            }
        }
        /// <summary>既定のレジストリキー</summary>
        public string DefaultRegistryKey { get; protected set; }
        /// <summary>ツールでサポートしているか</summary>
        public bool IsSupport { get; protected set; }

        public override string ToString()
        {
            var prefix = IsSupport ? "" : "(未対応)";
            var result = $"{prefix}{FullName}";
            return result;
        }

        /// <summary>システムボイスファイル名一覧</summary>
        public List<string> SystemVoiceFilenames()
        {
            var windowsFilenames = ExistsVoiceWindowsSoundType().Select(type => VoiceFileName(type));
            var explorerFilenames = ExistsVoiceExplorerSoundType().Select(type => VoiceFileName(type));
            var result = windowsFilenames.Concat(explorerFilenames).ToList();

            return result;
        }

        /// <summary>システムボイスで対応済みのサウンドを取得</summary>
        public List<WindowsSoundType> ExistsVoiceWindowsSoundType()
        {
            var types = new List<WindowsSoundType>();
            foreach (WindowsSoundType type in Enum.GetValues(typeof(WindowsSoundType)))
            {
                try
                {
                    VoiceFileName(type);
                    types.Add(type);
                }
                catch (Exception) { }

            }

            return types;
        }

        /// <summary>ボイスファイル名を取得</summary>
        /// <param name="sound">ボイス種類</param>
        /// <exception cref="ArgumentException">未対応のボイス</exception>
        public string VoiceFileName(WindowsSoundType sound)
        {
            switch (sound)
            {
                case WindowsSoundType.SystemError:
                    return $"{ShortName}-PC-01-システムエラー.wav";
                case WindowsSoundType.SystemNotification:
                    return $"{ShortName}-PC-02-システム通知.wav";
                case WindowsSoundType.DeviceConnect:
                    return $"{ShortName}-PC-03-デバイスの接続.wav";
                case WindowsSoundType.DeviceDisconnect:
                    return $"{ShortName}-PC-04-デバイスの切断.wav";
                case WindowsSoundType.DeviceConnectError:
                    return $"{ShortName}-PC-05-デバイスの接続の失敗.wav";
                case WindowsSoundType.BatteryLow:
                    return $"{ShortName}-PC-06-バッテリ低下アラーム.wav";
                case WindowsSoundType.BatteryEmpty:
                    return $"{ShortName}-PC-07-バッテリ切れアラーム.wav";
                case WindowsSoundType.ProgramError:
                    return $"{ShortName}-PC-08-プログラムエラー.wav";
                case WindowsSoundType.MessageInfomation:
                    return $"{ShortName}-PC-09-メッセージ（情報）.wav";
                case WindowsSoundType.MessageWarning:
                    return $"{ShortName}-PC-10-メッセージ（警告）.wav";
                case WindowsSoundType.GeneralWarning:
                    return $"{ShortName}-PC-11-一般の警告音.wav";
                case WindowsSoundType.PrintFinish:
                    return $"{ShortName}-PC-12-印刷完了.wav";
                case WindowsSoundType.NewMailNotification:
                    return $"{ShortName}-PC-13-新着メールの通知.wav";
                case WindowsSoundType.MaxWIndowSize:
                    return $"{ShortName}-PC-14-ウィンドウの最大化.wav";
                case WindowsSoundType.MinWindowSize:
                    return $"{ShortName}-PC-15-ウィンドウの最小化.wav";
                case WindowsSoundType.Notification:
                    return $"{ShortName}-PC-16-通知.wav";
                case WindowsSoundType.WindowsThemeChange:
                    return $"{ShortName}-PC-19-Window テーマの変更.wav";
                default:
                    throw new ArgumentException("未対応のボイス種類");
            }
        }

        /// <summary>システムボイスで対応済みのサウンドを取得</summary>
        public List<ExplorerSoundType> ExistsVoiceExplorerSoundType()
        {
            var types = new List<ExplorerSoundType>();
            foreach (ExplorerSoundType type in Enum.GetValues(typeof(ExplorerSoundType)))
            {
                try
                {
                    VoiceFileName(type);
                    types.Add(type);
                }
                catch (Exception) { }

            }

            return types;
        }

        /// <summary>ボイスファイル名を取得</summary>
        /// <param name="sound">ボイス種類</param>
        /// <exception cref="ArgumentException">未対応のボイス</exception>
        public string VoiceFileName(ExplorerSoundType sound)
        {
            switch (sound)
            {
                case ExplorerSoundType.EmptyTrash:
                    return $"{ShortName}-PC-17-ごみ箱を空にする.wav";
                case ExplorerSoundType.PopupWindowBlock:
                    return $"{ShortName}-PC-18-ポップアップウィンドウのブロック.wav";
                default:
                    throw new ArgumentException("未対応のボイス種類");
            }
        }
    }
}
