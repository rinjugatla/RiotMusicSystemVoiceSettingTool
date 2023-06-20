using Microsoft.WindowsAPICodePack.Dialogs;
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
using RiotMusicSystemVoiceSettingTool.Controller;
using System.IO;

namespace RiotMusicSystemVoiceSettingTool
{
    public partial class Form1 : Form
    {
        private string FormName = "";
        private ActorBaseModel CurrentSelectVoice = null;

        public Form1()
        {
            InitializeComponent();

            FormName = this.Text;
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
            SystemVoiceRegisterName_PlaceholderTextBox.Text = current.DefaultRegistryKey;
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

        /// <summary>システムボイスを登録</summary>
        private void SystemVoiceRegister_Button_Click(object sender, EventArgs e)
        {
            // 初期化
            ErrorLog_TextBox.Text = "";

            var registryController = new SystemVoiceRegistryController();
            registryController.ReadRegistrySetting();

            var directoryPath = SystemVoiceDirectory_TextBox.Text;
            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("システムボイスフォルダが存在しません。", FormName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string registryKeyName = SystemVoiceRegisterName_PlaceholderTextBox.Text;
            if (registryKeyName.Length == 0)
            {
                MessageBox.Show("サウンド項目名が未設定です。名前を入力してください。", FormName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool useDefaltSound = UseDefaultSystemSound_CheckBox.Checked;
            string error = registryController.RegistSystemVoice(useDefaltSound, directoryPath, registryKeyName, CurrentSelectVoice);
            ErrorLog_TextBox.Text = error;

            MessageBox.Show("システムボイスの登録が完了しました。", "システムボイスの登録", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
