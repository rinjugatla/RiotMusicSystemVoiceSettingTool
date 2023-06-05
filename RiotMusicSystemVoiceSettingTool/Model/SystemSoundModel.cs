using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotMusicSystemVoiceSettingTool.Model
{
    internal class SystemSoundModel
    {
        public enum WindowsSoundType
        {
            /// <summary>NFP完了</summary>
            NfpFinish,
            /// <summary>NFP接続</summary>
            NfpConnect,
            /// <summary>Windowsテーマの変更</summary>
            WindowsThemeChange,
            /// <summary>Windowsユーザアカウント制御</summary>
            WindowsUserAccountControl,
            /// <summary>インスタントメッセージの通知</summary>
            InstanceMessageNotification,
            /// <summary>システムエラー</summary>
            SystemError,
            /// <summary>システム通知</summary>
            SystemNotification,
            /// <summary>ツールバーバンドの表示</summary>
            ToolBarBandShow,
            /// <summary>デスクトップメール通知</summary>
            DesktopMailNotification,
            /// <summary>デバイス切断</summary>
            DeviceDisconnect,
            /// <summary>デバイス接続</summary>
            DeviceConnect,
            /// <summary>デバイス接続エラー</summary>
            DeviceConnectError,
            /// <summary>バッテリー低下</summary>
            BatteryLow,
            /// <summary>バッテリー切れ</summary>
            BatteryEmpty,
            /// <summary>プログラムエラー</summary>
            ProgramError,
            /// <summary>プログラム終了</summary>
            ProgramExit,
            /// <summary>プログラム起動</summary>
            ProgramStart,
            /// <summary>メッセージ(問い合わせ)</summary>
            MessageQuestion,
            /// <summary>情報メッセージ</summary>
            MessageInfomation,
            /// <summary>警告メッセージ</summary>
            MessageWarning,
            /// <summary>メッセージのシェイク</summary>
            MessageShake,
            /// <summary>メニューコマンド</summary>
            MenuCommand,
            /// <summary>メニューポップアップ</summary>
            MenuPopup,
            /// <summary>一般の警告</summary>
            GeneralWarning,
            /// <summary>予定表のアラーム</summary>
            ScheduleAlarm,
            /// <summary>元に戻す(拡大)</summary>
            ExpansionUndo,
            /// <summary>元に戻す(縮小)</summary>
            ShrinkUndo,
            /// <summary>印刷完了</summary>
            PrintFinish,
            /// <summary>新着テキストメッセージの通知</summary>
            NewMessageNotification,
            /// <summary>新着ファックスの通知</summary>
            NewFaxNotification,
            /// <summary>新着メール通知</summary>
            NewMailNotification,
            /// <summary>最大化</summary>
            MaxWIndowSize,
            /// <summary>最小化</summary>
            MinWindowSize,
            /// <summary>通知</summary>
            Notification,
            /// <summary>選択</summary>
            Select,
        }

        public enum ExplorerSoundType
        {
            /// <summary>ごみ箱を空にする</summary>
            EmptyTrash,
            /// <summary>ナビゲーション終了</summary>
            NavigationFinish,
            /// <summary>ナビゲーション開始</summary>
            NavigationStart,
            /// <summary>フィードの発見</summary>
            FeedDiscover,
            /// <summary>ポップアップウィンドウのブロック</summary>
            PopupWindowBlock,
            /// <summary>メニュー項目の移動</summary>
            MenuItemMove,
            /// <summary>通知バー</summary>
            NotificationBar,
        }

        /// <summary>レジストリパスを取得</summary>
        public static string RegistryPath(WindowsSoundType type)
        {
            string @base = @"AppEvents\Schemes\Apps\.Default\";
            string key = "";
            switch (type)
            {
                case WindowsSoundType.NfpFinish:
                    key = "Notification.Proximity"; break;
                case WindowsSoundType.NfpConnect:
                    key = "ProximityConnection"; break;
                case WindowsSoundType.WindowsThemeChange:
                    key = "ChangeTheme"; break;
                case WindowsSoundType.WindowsUserAccountControl:
                    key = "WindowsUAC"; break;
                case WindowsSoundType.InstanceMessageNotification:
                    key = "Notification.IM"; break;
                case WindowsSoundType.SystemError:
                    key = "SystemHand"; break;
                case WindowsSoundType.SystemNotification:
                    key = "SystemNotification"; break;
                case WindowsSoundType.ToolBarBandShow:
                    key = "ShowBand"; break;
                case WindowsSoundType.DesktopMailNotification:
                    key = "MailBeep"; break;
                case WindowsSoundType.DeviceDisconnect:
                    key = "DeviceDisconnect"; break;
                case WindowsSoundType.DeviceConnect:
                    key = "DeviceConnect"; break;
                case WindowsSoundType.DeviceConnectError:
                    key = "DeviceFail"; break;
                case WindowsSoundType.BatteryLow:
                    key = "LowBatteryAlarm"; break;
                case WindowsSoundType.BatteryEmpty:
                    key = "CriticalBatteryAlarm"; break;
                case WindowsSoundType.ProgramError:
                    key = "AppGPFault"; break;
                case WindowsSoundType.ProgramExit:
                    key = "Close"; break;
                case WindowsSoundType.ProgramStart:
                    key = "Open"; break;
                case WindowsSoundType.MessageQuestion:
                    key = "MessageQuestion"; break;
                case WindowsSoundType.MessageInfomation:
                    key = "SystemAsterisk"; break;
                case WindowsSoundType.MessageWarning:
                    key = "SystemExclamation"; break;
                case WindowsSoundType.MessageShake:
                    key = "MessageNudge"; break;
                case WindowsSoundType.MenuCommand:
                    key = "MenuCommand"; break;
                case WindowsSoundType.MenuPopup:
                    key = "MenuPopup"; break;
                case WindowsSoundType.GeneralWarning:
                    key = ".Default"; break;
                case WindowsSoundType.ScheduleAlarm:
                    key = "Notification.Reminder"; break;
                case WindowsSoundType.ExpansionUndo:
                    key = "RestoreUp"; break;
                case WindowsSoundType.ShrinkUndo:
                    key = "RestoreDown"; break;
                case WindowsSoundType.PrintFinish:
                    key = "PrintComplete"; break;
                case WindowsSoundType.NewMessageNotification:
                    key = "Notification.SMS"; break;
                case WindowsSoundType.NewFaxNotification:
                    key = "FaxBeep"; break;
                case WindowsSoundType.NewMailNotification:
                    key = "Mail"; break;
                case WindowsSoundType.MaxWIndowSize:
                    key = "Maximize"; break;
                case WindowsSoundType.MinWindowSize:
                    key = "Minimize"; break;
                case WindowsSoundType.Notification:
                    key = "Notification.Default"; break;
                case WindowsSoundType.Select:
                    key = "CCSelect"; break;
            }

            string path = @base + key;
            return path;
        }

        /// <summary>レジストリパスを取得</summary>
        public string RegistryPath(ExplorerSoundType type)
        {
            string @base = @"AppEvents\Schemes\Apps\Explorer\";
            string key = "";
            switch (type)
            {
                case ExplorerSoundType.EmptyTrash:
                    key = "EmptyRecycleBin"; break;
                case ExplorerSoundType.NavigationFinish:
                    key = "ActivatingDocument"; break;
                case ExplorerSoundType.NavigationStart:
                    key = "Navigating"; break;
                case ExplorerSoundType.FeedDiscover:
                    key = "FeedDiscovered"; break;
                case ExplorerSoundType.PopupWindowBlock:
                    key = "BlockedPopup"; break;
                case ExplorerSoundType.MenuItemMove:
                    key = "MoveMenuItem"; break;
                case ExplorerSoundType.NotificationBar:
                    key = "SecurityBand"; break;
            }

            string path = @base + key;
            return path;
        }
    }
}
