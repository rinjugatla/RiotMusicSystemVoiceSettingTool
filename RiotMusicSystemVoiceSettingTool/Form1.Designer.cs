﻿namespace RiotMusicSystemVoiceSettingTool
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SystemVoiceSelect_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SystemVoiceSele_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.SystemVoiceDirectory_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SystemVoiceDirectoryBrowse_Button = new System.Windows.Forms.Button();
            this.SystemVoiceRegister_Button = new System.Windows.Forms.Button();
            this.UseDefaultSystemSound_CheckBox = new System.Windows.Forms.CheckBox();
            this.ErrorLog_GroupBox = new System.Windows.Forms.GroupBox();
            this.ErrorLog_TextBox = new System.Windows.Forms.TextBox();
            this.SystemVoiceRegisterName_PlaceholderTextBox = new RiotMusicSystemVoiceSettingTool.CustomControll.PlaceholderTextBox();
            this.OpenSoundWindow_Button = new System.Windows.Forms.Button();
            this.ErrorLog_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SystemVoiceSelect_ComboBox
            // 
            this.SystemVoiceSelect_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SystemVoiceSelect_ComboBox.FormattingEnabled = true;
            this.SystemVoiceSelect_ComboBox.Location = new System.Drawing.Point(96, 12);
            this.SystemVoiceSelect_ComboBox.Name = "SystemVoiceSelect_ComboBox";
            this.SystemVoiceSelect_ComboBox.Size = new System.Drawing.Size(399, 20);
            this.SystemVoiceSelect_ComboBox.TabIndex = 0;
            this.SystemVoiceSelect_ComboBox.SelectedIndexChanged += new System.EventHandler(this.SystemVoiceSelect_ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "導入ボイス";
            // 
            // SystemVoiceSele_LinkLabel
            // 
            this.SystemVoiceSele_LinkLabel.AutoSize = true;
            this.SystemVoiceSele_LinkLabel.Location = new System.Drawing.Point(505, 15);
            this.SystemVoiceSele_LinkLabel.Name = "SystemVoiceSele_LinkLabel";
            this.SystemVoiceSele_LinkLabel.Size = new System.Drawing.Size(71, 12);
            this.SystemVoiceSele_LinkLabel.TabIndex = 2;
            this.SystemVoiceSele_LinkLabel.TabStop = true;
            this.SystemVoiceSele_LinkLabel.Text = "販売先ページ";
            this.SystemVoiceSele_LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SystemVoiceSele_LinkLabel_LinkClicked);
            // 
            // SystemVoiceDirectory_TextBox
            // 
            this.SystemVoiceDirectory_TextBox.Location = new System.Drawing.Point(96, 38);
            this.SystemVoiceDirectory_TextBox.Name = "SystemVoiceDirectory_TextBox";
            this.SystemVoiceDirectory_TextBox.Size = new System.Drawing.Size(399, 19);
            this.SystemVoiceDirectory_TextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "ボイスフォルダ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "サウンド登録名";
            // 
            // SystemVoiceDirectoryBrowse_Button
            // 
            this.SystemVoiceDirectoryBrowse_Button.Location = new System.Drawing.Point(501, 36);
            this.SystemVoiceDirectoryBrowse_Button.Name = "SystemVoiceDirectoryBrowse_Button";
            this.SystemVoiceDirectoryBrowse_Button.Size = new System.Drawing.Size(75, 23);
            this.SystemVoiceDirectoryBrowse_Button.TabIndex = 5;
            this.SystemVoiceDirectoryBrowse_Button.Text = "参照";
            this.SystemVoiceDirectoryBrowse_Button.UseVisualStyleBackColor = true;
            this.SystemVoiceDirectoryBrowse_Button.Click += new System.EventHandler(this.SystemVoiceDirectoryBrowse_Button_Click);
            // 
            // SystemVoiceRegister_Button
            // 
            this.SystemVoiceRegister_Button.Location = new System.Drawing.Point(501, 88);
            this.SystemVoiceRegister_Button.Name = "SystemVoiceRegister_Button";
            this.SystemVoiceRegister_Button.Size = new System.Drawing.Size(75, 23);
            this.SystemVoiceRegister_Button.TabIndex = 6;
            this.SystemVoiceRegister_Button.Text = "登録";
            this.SystemVoiceRegister_Button.UseVisualStyleBackColor = true;
            this.SystemVoiceRegister_Button.Click += new System.EventHandler(this.SystemVoiceRegister_Button_Click);
            // 
            // UseDefaultSystemSound_CheckBox
            // 
            this.UseDefaultSystemSound_CheckBox.AutoSize = true;
            this.UseDefaultSystemSound_CheckBox.Location = new System.Drawing.Point(39, 91);
            this.UseDefaultSystemSound_CheckBox.Name = "UseDefaultSystemSound_CheckBox";
            this.UseDefaultSystemSound_CheckBox.Size = new System.Drawing.Size(339, 16);
            this.UseDefaultSystemSound_CheckBox.TabIndex = 8;
            this.UseDefaultSystemSound_CheckBox.Text = "システムボイスが存在しない場合はデフォルトシステムサウンドを使用";
            this.UseDefaultSystemSound_CheckBox.UseVisualStyleBackColor = true;
            // 
            // ErrorLog_GroupBox
            // 
            this.ErrorLog_GroupBox.Controls.Add(this.ErrorLog_TextBox);
            this.ErrorLog_GroupBox.Location = new System.Drawing.Point(14, 115);
            this.ErrorLog_GroupBox.Name = "ErrorLog_GroupBox";
            this.ErrorLog_GroupBox.Size = new System.Drawing.Size(562, 251);
            this.ErrorLog_GroupBox.TabIndex = 9;
            this.ErrorLog_GroupBox.TabStop = false;
            this.ErrorLog_GroupBox.Text = "ログ";
            // 
            // ErrorLog_TextBox
            // 
            this.ErrorLog_TextBox.Location = new System.Drawing.Point(6, 18);
            this.ErrorLog_TextBox.Multiline = true;
            this.ErrorLog_TextBox.Name = "ErrorLog_TextBox";
            this.ErrorLog_TextBox.ReadOnly = true;
            this.ErrorLog_TextBox.Size = new System.Drawing.Size(550, 227);
            this.ErrorLog_TextBox.TabIndex = 0;
            // 
            // SystemVoiceRegisterName_PlaceholderTextBox
            // 
            this.SystemVoiceRegisterName_PlaceholderTextBox.Location = new System.Drawing.Point(96, 63);
            this.SystemVoiceRegisterName_PlaceholderTextBox.Name = "SystemVoiceRegisterName_PlaceholderTextBox";
            this.SystemVoiceRegisterName_PlaceholderTextBox.PlaceholderColor = System.Drawing.Color.Empty;
            this.SystemVoiceRegisterName_PlaceholderTextBox.PlaceholderText = "半角英数字で入力してください";
            this.SystemVoiceRegisterName_PlaceholderTextBox.Size = new System.Drawing.Size(480, 19);
            this.SystemVoiceRegisterName_PlaceholderTextBox.TabIndex = 7;
            // 
            // OpenSoundWindow_Button
            // 
            this.OpenSoundWindow_Button.Location = new System.Drawing.Point(384, 88);
            this.OpenSoundWindow_Button.Name = "OpenSoundWindow_Button";
            this.OpenSoundWindow_Button.Size = new System.Drawing.Size(111, 23);
            this.OpenSoundWindow_Button.TabIndex = 6;
            this.OpenSoundWindow_Button.Text = "サウンド設定を開く";
            this.OpenSoundWindow_Button.UseVisualStyleBackColor = true;
            this.OpenSoundWindow_Button.Click += new System.EventHandler(this.OpenSoundWindow_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 378);
            this.Controls.Add(this.ErrorLog_GroupBox);
            this.Controls.Add(this.OpenSoundWindow_Button);
            this.Controls.Add(this.UseDefaultSystemSound_CheckBox);
            this.Controls.Add(this.SystemVoiceRegisterName_PlaceholderTextBox);
            this.Controls.Add(this.SystemVoiceRegister_Button);
            this.Controls.Add(this.SystemVoiceDirectoryBrowse_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SystemVoiceDirectory_TextBox);
            this.Controls.Add(this.SystemVoiceSele_LinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SystemVoiceSelect_ComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RiotMusicシステムボイス設定ツール";
            this.ErrorLog_GroupBox.ResumeLayout(false);
            this.ErrorLog_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SystemVoiceSelect_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel SystemVoiceSele_LinkLabel;
        private System.Windows.Forms.TextBox SystemVoiceDirectory_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SystemVoiceDirectoryBrowse_Button;
        private System.Windows.Forms.Button SystemVoiceRegister_Button;
        private CustomControll.PlaceholderTextBox SystemVoiceRegisterName_PlaceholderTextBox;
        private System.Windows.Forms.CheckBox UseDefaultSystemSound_CheckBox;
        private System.Windows.Forms.GroupBox ErrorLog_GroupBox;
        private System.Windows.Forms.TextBox ErrorLog_TextBox;
        private System.Windows.Forms.Button OpenSoundWindow_Button;
    }
}

