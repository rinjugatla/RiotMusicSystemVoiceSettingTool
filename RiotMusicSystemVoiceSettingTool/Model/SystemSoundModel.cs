using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotMusicSystemVoiceSettingTool.Model
{
    internal class SystemSoundModel
    {
        public enum SoundProgramType
        {
            Windows,
            Explorer,
            Other
        }

        public enum SoundType
        {
            #region Windows
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
            /// <summary>プログラム開始</summary>
            ProgramStart,
            /// <summary>メッセージ(問い合わせ)</summary>
            MessageInquiry,
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
            #endregion

            #region Explorer
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
            #endregion
        }
    }
}
