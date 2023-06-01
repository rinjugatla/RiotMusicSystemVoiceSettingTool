using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotMusicSystemVoiceSettingTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            SystemVoiceSelect_ComboBox.SelectedIndex = 0;
        }

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
