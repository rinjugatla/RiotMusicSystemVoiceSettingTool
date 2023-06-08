using Microsoft.WindowsAPICodePack.Dialogs;
using RiotMusicSystemVoiceSettingTool.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiotMusicSystemVoiceSettingTool.Model.RiotMusicSysmteVoice;

namespace RiotMusicSystemVoiceSettingTool
{
    public partial class Form1 : Form
    {
        private ActorBaseModel CurrentSelectVoice = null;

        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        /// <summary>フォーム初期化</summary>
        private void InitForm()
        {
            SystemVoiceSelect_ComboBox.Items.AddRange(new ActorBaseModel[]{
                new CocoaModel(),
                new IoriModel(),
                new MionaModel(),
                new AnkoModel()
            });

            SystemVoiceSelect_ComboBox.SelectedIndex = 0;
        }

        /// <summary>選択中のボイスモデルの更新</summary>
        private void SystemVoiceSelect_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ComboBox;
            var current = combo.SelectedItem as ActorBaseModel;
            if(current == null) { return; }

            CurrentSelectVoice = current;
        }

        /// <summary>ボイス販売ページに遷移</summary>
        private void SystemVoiceSele_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentSelectVoice == null) { return; }

            Process.Start(CurrentSelectVoice.StoreUrl);
        }

        /// <summary>システムボイスフォルダを設定</summary>
        private void SystemVoiceDirectoryBrowse_Button_Click(object sender, EventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog("システムボイスフォルダを選択") { IsFolderPicker = true })
            {
                var isOk = dialog.ShowDialog() == CommonFileDialogResult.Ok;
                if (!isOk) { return; }

                SystemVoiceDirectory_TextBox.Text = dialog.FileName;
            }
        }
    }
}
