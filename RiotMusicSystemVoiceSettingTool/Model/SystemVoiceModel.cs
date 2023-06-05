using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiotMusicSystemVoiceSettingTool.Model.SystemSoundModel;

namespace RiotMusicSystemVoiceSettingTool.Model
{
    internal class SystemVoiceModel
    {
        /// <summary>ボイス担当者</summary>
        public enum ActorType
        {
            /// <summary>道明寺ここあ</summary>
            Cocoa,
            /// <summary>松永依織</summary>
            Iori,
            /// <summary>皇美緒奈</summary>
            Miona,
            /// <summary>朝倉杏子</summary>
            Anko
        }

        /// <summary>ボイス担当者</summary>
        public ActorType Actor { get; private set; }
        /// <summary>フルネーム</summary>
        public string FullName { get; private set; }
        /// <summary>ファイル名用の短い名前</summary>
        private string ShortName { get; set; }
        /// <summary>販売URL</summary>
        public string StoreUrl { get; private set; }

        public override string ToString()
        {
            if(Actor == ActorType.Cocoa || Actor == ActorType.Iori) { return $"(未対応){FullName}"; }
            return FullName;
        }
        
        /// <param name="actor">ボイス担当者</param>
        public SystemVoiceModel(ActorType actor)
        {
            Actor = actor;

            InitFullName();
            InitShortName();
            InitStoreUrl();
        }

        /// <summary>フルネームを設定</summary>
        private void InitFullName()
        {
            switch (Actor)
            {
                case ActorType.Cocoa:
                    FullName = "道明寺ここあ"; break;
                case ActorType.Iori:
                    FullName = "松永依織"; break;
                case ActorType.Miona:
                    FullName = "皇美緒奈"; break;
                case ActorType.Anko:
                    FullName = "朝倉杏子"; break;
            }
        }

        /// <summary>ファイル名用の短い名前を設定</summary>
        private void InitShortName()
        {
            switch (Actor)
            {
                case ActorType.Cocoa:
                    ShortName = "ここあ"; break;
                case ActorType.Iori:
                    ShortName = "依織"; break;
                case ActorType.Miona:
                    ShortName = "美緒奈"; break;
                case ActorType.Anko:
                    ShortName = "杏子"; break;
            }
        }

        /// <summary>販売URLを設定</summary>
        private void InitStoreUrl()
        {
            string baseUrl = "https://riotmusic.store/collections/2305-bw-system-voice/products/";
            string postfix = "";
            switch (Actor)
            {
                case ActorType.Cocoa:
                    postfix = "2305-bw-system-voice-cocoa"; break;
                case ActorType.Iori:
                    postfix = "2305-bw-systemu-voice-iori";  break;
                case ActorType.Miona:
                    postfix = "2305-bw-system-voice-miona";  break;
                case ActorType.Anko:
                    postfix = "2305-bw-system-voice-anko";  break;
            }
            StoreUrl = baseUrl + postfix;
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
