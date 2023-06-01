using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>ボイス種類</summary>
        public enum VoiceType
        {
            /// <summary>システムエラー</summary>
            SystemError = 1,
            /// <summary>システム通知</summary>
            SystemNotification = 2,
            /// <summary>デバイスの接続</summary>
            DeviceConnect = 3,
            /// <summary>デバイスの切断</summary>
            DeviceDisconnect = 4,
            /// <summary>デバイスの接続失敗</summary>
            DeviceConnectError = 5,
            /// <summary>バッテリー低下アラーム</summary>
            BatteryLow = 6,
            /// <summary>バッテリー切れアラーム</summary>
            BatteryEmpty = 7,
            /// <summary>プログラムエラー</summary>
            ProgramError = 8,
            /// <summary>情報メッセージ</summary>
            InfomationMessage = 9,
            /// <summary>警告メッセージ</summary>
            WarningMessage = 10,
            /// <summary>一般の警告</summary>
            GeneralWarning = 11,
            /// <summary>印刷完了</summary>
            PrintFinish = 12,
            /// <summary>新着メールの通知</summary>
            NewMailNotification = 13,
            /// <summary>ウィンドウサイズの最大化</summary>
            MaxWIndowSize = 14,
            /// <summary>ウィンドウの最小化</summary>
            MinWindowSize = 15,
            /// <summary>通知</summary>
            Notification = 16,
            /// <summary>ごみ箱をカラにする</summary>
            EmptyTrash = 17,
            /// <summary>ポップアップウィンドウのブロック</summary>
            BlockPopupWindow = 18,
            /// <summary>Windowsテーマの変更</summary>
            WindowsThemeChange = 19,
        }

        /// <summary>ボイス担当者</summary>
        public ActorType Actor { get; private set; }
        /// <summary>フルネーム</summary>
        public string FullName { get; private set; }
        /// <summary>ファイル名用の短い名前</summary>
        private string ShortName { get; set; }
        
        /// <param name="actor">ボイス担当者</param>
        public SystemVoiceModel(ActorType actor)
        {
            Actor = actor;

            InitFullName();
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

        /// <summary>ボイスファイル名を取得</summary>
        /// <param name="voice">ボイス種類</param>
        /// <exception cref="ArgumentException">未対応のボイス</exception>
        public string VoiceFileName(VoiceType voice)
        {
            switch (voice)
            {
                case VoiceType.SystemError:
                    return $"{ShortName}-PC-01-システムエラー.wav";
                case VoiceType.SystemNotification:
                    return $"{ShortName}-PC-02-システム通知.wav";
                case VoiceType.DeviceConnect:
                    return $"{ShortName}-PC-03-デバイスの接続.wav";
                case VoiceType.DeviceDisconnect:
                    return $"{ShortName}-PC-04-デバイスの切断.wav";
                case VoiceType.DeviceConnectError:
                    return $"{ShortName}-PC-05-デバイスの接続の失敗.wav";
                case VoiceType.BatteryLow:
                    return $"{ShortName}-PC-06-バッテリ低下アラーム.wav";
                case VoiceType.BatteryEmpty:
                    return $"{ShortName}-PC-07-バッテリ切れアラーム.wav";
                case VoiceType.ProgramError:
                    return $"{ShortName}-PC-08-プログラムエラー.wav";
                case VoiceType.InfomationMessage:
                    return $"{ShortName}-PC-09-メッセージ（情報）.wav";
                case VoiceType.WarningMessage:
                    return $"{ShortName}-PC-10-メッセージ（警告）.wav";
                case VoiceType.GeneralWarning:
                    return $"{ShortName}-PC-11-一般の警告音.wav";
                case VoiceType.PrintFinish:
                    return $"{ShortName}-PC-12-印刷完了.wav";
                case VoiceType.NewMailNotification:
                    return $"{ShortName}-PC-13-新着メールの通知.wav";
                case VoiceType.MaxWIndowSize:
                    return $"{ShortName}-PC-14-ウィンドウの最大化.wav";
                case VoiceType.MinWindowSize:
                    return $"{ShortName}-PC-15-ウィンドウの最小化.wav";
                case VoiceType.Notification:
                    return $"{ShortName}-PC-16-通知.wav";
                case VoiceType.EmptyTrash:
                    return $"{ShortName}-PC-17-ごみ箱を空にする.wav";
                case VoiceType.BlockPopupWindow:
                    return $"{ShortName}-PC-18-ポップアップウィンドウのブロック.wav";
                case VoiceType.WindowsThemeChange:
                    return $"{ShortName}-PC-19-Window テーマの変更.wav";
                default:
                    throw new ArgumentException("未対応のボイス種類");
            }
        }

    }
}
