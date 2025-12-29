namespace FinalProjectUI
{
    partial class Cmd
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
            this.cmdOutputBox = new System.Windows.Forms.TextBox();
            this.Hide_Button = new ReaLTaiizor.Controls.Button();
            this.nightLabel1 = new ReaLTaiizor.Controls.NightLabel();
            this.SuspendLayout();
            // 
            // cmdOutputBox
            // 
            this.cmdOutputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.cmdOutputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cmdOutputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdOutputBox.Font = new System.Drawing.Font("Javanese Text", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOutputBox.ForeColor = System.Drawing.Color.Silver;
            this.cmdOutputBox.Location = new System.Drawing.Point(0, 160);
            this.cmdOutputBox.Multiline = true;
            this.cmdOutputBox.Name = "cmdOutputBox";
            this.cmdOutputBox.ReadOnly = true;
            this.cmdOutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cmdOutputBox.Size = new System.Drawing.Size(462, 628);
            this.cmdOutputBox.TabIndex = 1;
            // 
            // Hide_Button
            // 
            this.Hide_Button.BackColor = System.Drawing.Color.Transparent;
            this.Hide_Button.BorderColor = System.Drawing.Color.Silver;
            this.Hide_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Hide_Button.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Hide_Button.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.Hide_Button.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hide_Button.Image = null;
            this.Hide_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Hide_Button.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.Hide_Button.Location = new System.Drawing.Point(388, 12);
            this.Hide_Button.Name = "Hide_Button";
            this.Hide_Button.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Hide_Button.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Hide_Button.Size = new System.Drawing.Size(62, 40);
            this.Hide_Button.TabIndex = 7;
            this.Hide_Button.Text = "Back";
            this.Hide_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Hide_Button.Click += new System.EventHandler(this.Hide_Button_Click);
            // 
            // nightLabel1
            // 
            this.nightLabel1.AutoSize = true;
            this.nightLabel1.BackColor = System.Drawing.Color.Transparent;
            this.nightLabel1.Font = new System.Drawing.Font("Cambria Math", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nightLabel1.ForeColor = System.Drawing.Color.Silver;
            this.nightLabel1.Location = new System.Drawing.Point(58, 11);
            this.nightLabel1.Name = "nightLabel1";
            this.nightLabel1.Size = new System.Drawing.Size(343, 151);
            this.nightLabel1.TabIndex = 8;
            this.nightLabel1.Text = "Smart Analysis Output";
            // 
            // Cmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(462, 788);
            this.ControlBox = false;
            this.Controls.Add(this.cmdOutputBox);
            this.Controls.Add(this.Hide_Button);
            this.Controls.Add(this.nightLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cmd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Cmd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox cmdOutputBox;
        private ReaLTaiizor.Controls.Button Hide_Button;
        private ReaLTaiizor.Controls.NightLabel nightLabel1;
    }
}