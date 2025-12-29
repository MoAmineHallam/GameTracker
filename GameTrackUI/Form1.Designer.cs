namespace FinalProjectUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.nightHeaderLabel1 = new ReaLTaiizor.Controls.NightHeaderLabel();
            this.InputVideoBtn = new ReaLTaiizor.Controls.Button();
            this.football = new System.Windows.Forms.PictureBox();
            this.OutputVideo = new LibVLCSharp.WinForms.VideoView();
            this.inputVideo = new LibVLCSharp.WinForms.VideoView();
            this.AnalyzeBtn = new ReaLTaiizor.Controls.Button();
            this.AnalizingLabel = new System.Windows.Forms.Label();
            this.PLayPauseBtn = new System.Windows.Forms.Label();
            this.FullScreenBtn = new System.Windows.Forms.Label();
            this.AnalyzeDoubleClick = new System.Windows.Forms.Label();
            this.UploadVdFst = new System.Windows.Forms.Label();
            this.PlayPauseBtnOutput = new System.Windows.Forms.Label();
            this.FullScreenBtnOutput = new System.Windows.Forms.Label();
            this.cmd_button = new ReaLTaiizor.Controls.FoxButton();
            this.Download_Button = new ReaLTaiizor.Controls.FoxButton();
            ((System.ComponentModel.ISupportInitialize)(this.football)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.White;
            this.nightControlBox1.EnableMaximizeButton = false;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.White;
            this.nightControlBox1.Location = new System.Drawing.Point(871, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            // 
            // nightHeaderLabel1
            // 
            this.nightHeaderLabel1.AutoSize = true;
            this.nightHeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.nightHeaderLabel1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nightHeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightHeaderLabel1.LeftSideForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.nightHeaderLabel1.Location = new System.Drawing.Point(7, 8);
            this.nightHeaderLabel1.Name = "nightHeaderLabel1";
            this.nightHeaderLabel1.RightSideForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(176)))));
            this.nightHeaderLabel1.Side = ReaLTaiizor.Controls.NightHeaderLabel.PanelSide.LeftPanel;
            this.nightHeaderLabel1.Size = new System.Drawing.Size(110, 31);
            this.nightHeaderLabel1.TabIndex = 3;
            this.nightHeaderLabel1.Text = "GameTrack";
            this.nightHeaderLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nightHeaderLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.nightHeaderLabel1.UseCompatibleTextRendering = true;
            // 
            // InputVideoBtn
            // 
            this.InputVideoBtn.BackColor = System.Drawing.Color.Transparent;
            this.InputVideoBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.InputVideoBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InputVideoBtn.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.InputVideoBtn.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.InputVideoBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputVideoBtn.Image = null;
            this.InputVideoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InputVideoBtn.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.InputVideoBtn.Location = new System.Drawing.Point(143, 385);
            this.InputVideoBtn.Name = "InputVideoBtn";
            this.InputVideoBtn.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.InputVideoBtn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.InputVideoBtn.Size = new System.Drawing.Size(116, 41);
            this.InputVideoBtn.TabIndex = 6;
            this.InputVideoBtn.Text = "Input Video";
            this.InputVideoBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.InputVideoBtn.Click += new System.EventHandler(this.InputVideoBtn_Click);
            // 
            // football
            // 
            this.football.Image = ((System.Drawing.Image)(resources.GetObject("football.Image")));
            this.football.Location = new System.Drawing.Point(254, 113);
            this.football.Name = "football";
            this.football.Size = new System.Drawing.Size(489, 281);
            this.football.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.football.TabIndex = 7;
            this.football.TabStop = false;
            // 
            // OutputVideo
            // 
            this.OutputVideo.BackColor = System.Drawing.Color.Black;
            this.OutputVideo.Location = new System.Drawing.Point(602, 148);
            this.OutputVideo.MediaPlayer = null;
            this.OutputVideo.Name = "OutputVideo";
            this.OutputVideo.Size = new System.Drawing.Size(380, 214);
            this.OutputVideo.TabIndex = 8;
            this.OutputVideo.Text = "videoView1";
            // 
            // inputVideo
            // 
            this.inputVideo.BackColor = System.Drawing.Color.Black;
            this.inputVideo.Location = new System.Drawing.Point(33, 148);
            this.inputVideo.MediaPlayer = null;
            this.inputVideo.Name = "inputVideo";
            this.inputVideo.Size = new System.Drawing.Size(354, 214);
            this.inputVideo.TabIndex = 9;
            this.inputVideo.Text = "videoView2";
            // 
            // AnalyzeBtn
            // 
            this.AnalyzeBtn.BackColor = System.Drawing.Color.Transparent;
            this.AnalyzeBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.AnalyzeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnalyzeBtn.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.AnalyzeBtn.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.AnalyzeBtn.Font = new System.Drawing.Font("Nirmala UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyzeBtn.Image = null;
            this.AnalyzeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AnalyzeBtn.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.AnalyzeBtn.Location = new System.Drawing.Point(436, 456);
            this.AnalyzeBtn.Name = "AnalyzeBtn";
            this.AnalyzeBtn.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.AnalyzeBtn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.AnalyzeBtn.Size = new System.Drawing.Size(129, 47);
            this.AnalyzeBtn.TabIndex = 10;
            this.AnalyzeBtn.Text = "Analyze";
            this.AnalyzeBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.AnalyzeBtn.Click += new System.EventHandler(this.AnalyzBtn_Click);
            // 
            // AnalizingLabel
            // 
            this.AnalizingLabel.AutoSize = true;
            this.AnalizingLabel.BackColor = System.Drawing.Color.Black;
            this.AnalizingLabel.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Italic);
            this.AnalizingLabel.ForeColor = System.Drawing.Color.White;
            this.AnalizingLabel.Location = new System.Drawing.Point(749, 242);
            this.AnalizingLabel.Name = "AnalizingLabel";
            this.AnalizingLabel.Size = new System.Drawing.Size(87, 21);
            this.AnalizingLabel.TabIndex = 11;
            this.AnalizingLabel.Text = "Analyzing...";
            // 
            // PLayPauseBtn
            // 
            this.PLayPauseBtn.AutoSize = true;
            this.PLayPauseBtn.BackColor = System.Drawing.Color.Black;
            this.PLayPauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PLayPauseBtn.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLayPauseBtn.ForeColor = System.Drawing.Color.White;
            this.PLayPauseBtn.Location = new System.Drawing.Point(33, 340);
            this.PLayPauseBtn.Name = "PLayPauseBtn";
            this.PLayPauseBtn.Size = new System.Drawing.Size(23, 20);
            this.PLayPauseBtn.TabIndex = 14;
            this.PLayPauseBtn.Text = "▶";
            this.PLayPauseBtn.Click += new System.EventHandler(this.PLayPauseBtn_Click);
            // 
            // FullScreenBtn
            // 
            this.FullScreenBtn.AutoSize = true;
            this.FullScreenBtn.BackColor = System.Drawing.Color.Black;
            this.FullScreenBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FullScreenBtn.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullScreenBtn.ForeColor = System.Drawing.Color.White;
            this.FullScreenBtn.Location = new System.Drawing.Point(362, 339);
            this.FullScreenBtn.Name = "FullScreenBtn";
            this.FullScreenBtn.Size = new System.Drawing.Size(25, 21);
            this.FullScreenBtn.TabIndex = 15;
            this.FullScreenBtn.Text = "⛶";
            this.FullScreenBtn.Click += new System.EventHandler(this.FullScreenBtn_Click);
            // 
            // AnalyzeDoubleClick
            // 
            this.AnalyzeDoubleClick.AutoSize = true;
            this.AnalyzeDoubleClick.BackColor = System.Drawing.Color.Transparent;
            this.AnalyzeDoubleClick.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Italic);
            this.AnalyzeDoubleClick.ForeColor = System.Drawing.Color.Snow;
            this.AnalyzeDoubleClick.Location = new System.Drawing.Point(341, 411);
            this.AnalyzeDoubleClick.Name = "AnalyzeDoubleClick";
            this.AnalyzeDoubleClick.Size = new System.Drawing.Size(350, 21);
            this.AnalyzeDoubleClick.TabIndex = 16;
            this.AnalyzeDoubleClick.Text = "Please wait Patiently the video is being analyzed...";
            this.AnalyzeDoubleClick.Visible = false;
            // 
            // UploadVdFst
            // 
            this.UploadVdFst.AutoSize = true;
            this.UploadVdFst.BackColor = System.Drawing.Color.Transparent;
            this.UploadVdFst.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Italic);
            this.UploadVdFst.ForeColor = System.Drawing.Color.Snow;
            this.UploadVdFst.Location = new System.Drawing.Point(371, 411);
            this.UploadVdFst.Name = "UploadVdFst";
            this.UploadVdFst.Size = new System.Drawing.Size(279, 21);
            this.UploadVdFst.TabIndex = 17;
            this.UploadVdFst.Text = "Please  input a video to start analyizing";
            this.UploadVdFst.Visible = false;
            // 
            // PlayPauseBtnOutput
            // 
            this.PlayPauseBtnOutput.AutoSize = true;
            this.PlayPauseBtnOutput.BackColor = System.Drawing.Color.Black;
            this.PlayPauseBtnOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayPauseBtnOutput.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayPauseBtnOutput.ForeColor = System.Drawing.Color.White;
            this.PlayPauseBtnOutput.Location = new System.Drawing.Point(602, 341);
            this.PlayPauseBtnOutput.Name = "PlayPauseBtnOutput";
            this.PlayPauseBtnOutput.Size = new System.Drawing.Size(23, 20);
            this.PlayPauseBtnOutput.TabIndex = 18;
            this.PlayPauseBtnOutput.Text = "▶";
            this.PlayPauseBtnOutput.Click += new System.EventHandler(this.PlayPauseBtnOutput_Click);
            // 
            // FullScreenBtnOutput
            // 
            this.FullScreenBtnOutput.AutoSize = true;
            this.FullScreenBtnOutput.BackColor = System.Drawing.Color.Black;
            this.FullScreenBtnOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FullScreenBtnOutput.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullScreenBtnOutput.ForeColor = System.Drawing.Color.White;
            this.FullScreenBtnOutput.Location = new System.Drawing.Point(958, 340);
            this.FullScreenBtnOutput.Name = "FullScreenBtnOutput";
            this.FullScreenBtnOutput.Size = new System.Drawing.Size(25, 21);
            this.FullScreenBtnOutput.TabIndex = 19;
            this.FullScreenBtnOutput.Text = "⛶";
            this.FullScreenBtnOutput.Click += new System.EventHandler(this.FullScreenBtnOutput_Click);
            // 
            // cmd_button
            // 
            this.cmd_button.BackColor = System.Drawing.Color.Transparent;
            this.cmd_button.BaseColor = System.Drawing.Color.Transparent;
            this.cmd_button.BorderColor = System.Drawing.Color.White;
            this.cmd_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_button.DisabledBaseColor = System.Drawing.Color.Transparent;
            this.cmd_button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.cmd_button.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.cmd_button.DownColor = System.Drawing.Color.Transparent;
            this.cmd_button.EnabledCalc = true;
            this.cmd_button.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_button.ForeColor = System.Drawing.Color.White;
            this.cmd_button.Location = new System.Drawing.Point(897, 371);
            this.cmd_button.Name = "cmd_button";
            this.cmd_button.OverColor = System.Drawing.Color.Transparent;
            this.cmd_button.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cmd_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmd_button.Size = new System.Drawing.Size(30, 25);
            this.cmd_button.TabIndex = 20;
            this.cmd_button.Text = ">_";
            this.cmd_button.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.cmd_button_Click);
            // 
            // Download_Button
            // 
            this.Download_Button.BackColor = System.Drawing.Color.Transparent;
            this.Download_Button.BackgroundImage = global::FinalProjectUI.Properties.Resources.icons8_download_24;
            this.Download_Button.BaseColor = System.Drawing.Color.Transparent;
            this.Download_Button.BorderColor = System.Drawing.Color.Transparent;
            this.Download_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Download_Button.DisabledBaseColor = System.Drawing.Color.Transparent;
            this.Download_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Download_Button.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Download_Button.DownColor = System.Drawing.Color.Transparent;
            this.Download_Button.EnabledCalc = true;
            this.Download_Button.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Download_Button.ForeColor = System.Drawing.Color.White;
            this.Download_Button.Location = new System.Drawing.Point(942, 372);
            this.Download_Button.Name = "Download_Button";
            this.Download_Button.OverColor = System.Drawing.Color.Transparent;
            this.Download_Button.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.Download_Button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Download_Button.Size = new System.Drawing.Size(25, 24);
            this.Download_Button.TabIndex = 21;
            this.Download_Button.Visible = false;
            this.Download_Button.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.Download_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(994, 560);
            this.ControlBox = false;
            this.Controls.Add(this.Download_Button);
            this.Controls.Add(this.cmd_button);
            this.Controls.Add(this.FullScreenBtnOutput);
            this.Controls.Add(this.PlayPauseBtnOutput);
            this.Controls.Add(this.UploadVdFst);
            this.Controls.Add(this.AnalyzeDoubleClick);
            this.Controls.Add(this.FullScreenBtn);
            this.Controls.Add(this.PLayPauseBtn);
            this.Controls.Add(this.AnalizingLabel);
            this.Controls.Add(this.AnalyzeBtn);
            this.Controls.Add(this.inputVideo);
            this.Controls.Add(this.OutputVideo);
            this.Controls.Add(this.InputVideoBtn);
            this.Controls.Add(this.nightHeaderLabel1);
            this.Controls.Add(this.nightControlBox1);
            this.Controls.Add(this.football);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.football)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private ReaLTaiizor.Controls.NightHeaderLabel nightHeaderLabel1;
        private ReaLTaiizor.Controls.Button InputVideoBtn;
        private System.Windows.Forms.PictureBox football;
        private LibVLCSharp.WinForms.VideoView OutputVideo;
        private LibVLCSharp.WinForms.VideoView inputVideo;
        private ReaLTaiizor.Controls.Button AnalyzeBtn;
        private System.Windows.Forms.Label AnalizingLabel;
        private System.Windows.Forms.Label PLayPauseBtn;
        private System.Windows.Forms.Label FullScreenBtn;
        private System.Windows.Forms.Label AnalyzeDoubleClick;
        private System.Windows.Forms.Label UploadVdFst;
        private System.Windows.Forms.Label PlayPauseBtnOutput;
        private System.Windows.Forms.Label FullScreenBtnOutput;
        private ReaLTaiizor.Controls.FoxButton cmd_button;
        private ReaLTaiizor.Controls.FoxButton Download_Button;
    }
}

