namespace fadAuto
{
    partial class CopyFiles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyFiles));
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRemaiing = new System.Windows.Forms.Label();
            this.prgCopy = new System.Windows.Forms.ProgressBar();
            this.butOk = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblRemainingText = new System.Windows.Forms.Label();
            this.lblCurrentText = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(24, 64);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(80, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "FlashAir-Status:";
            // 
            // lblRemaiing
            // 
            this.lblRemaiing.AutoSize = true;
            this.lblRemaiing.Location = new System.Drawing.Point(24, 96);
            this.lblRemaiing.Name = "lblRemaiing";
            this.lblRemaiing.Size = new System.Drawing.Size(81, 13);
            this.lblRemaiing.TabIndex = 1;
            this.lblRemaiing.Text = "Remaining files:";
            // 
            // prgCopy
            // 
            this.prgCopy.Location = new System.Drawing.Point(27, 160);
            this.prgCopy.Name = "prgCopy";
            this.prgCopy.Size = new System.Drawing.Size(664, 23);
            this.prgCopy.TabIndex = 2;
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(615, 190);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(24, 128);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(60, 13);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Current file:";
            // 
            // lblStatusText
            // 
            this.lblStatusText.Location = new System.Drawing.Point(111, 64);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(579, 23);
            this.lblStatusText.TabIndex = 5;
            // 
            // lblRemainingText
            // 
            this.lblRemainingText.Location = new System.Drawing.Point(112, 96);
            this.lblRemainingText.Name = "lblRemainingText";
            this.lblRemainingText.Size = new System.Drawing.Size(579, 23);
            this.lblRemainingText.TabIndex = 6;
            // 
            // lblCurrentText
            // 
            this.lblCurrentText.Location = new System.Drawing.Point(111, 128);
            this.lblCurrentText.Name = "lblCurrentText";
            this.lblCurrentText.Size = new System.Drawing.Size(579, 23);
            this.lblCurrentText.TabIndex = 7;
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "Automatic Download (not connected)";
            this.trayIcon.BalloonTipTitle = "FlashAirDownloader";
            this.trayIcon.ContextMenuStrip = this.ctxTray;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "FlashAirDownloader";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // ctxTray
            // 
            this.ctxTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAbout,
            this.ctxClose});
            this.ctxTray.Name = "ctxTray";
            this.ctxTray.Size = new System.Drawing.Size(108, 48);
            // 
            // ctxAbout
            // 
            this.ctxAbout.Name = "ctxAbout";
            this.ctxAbout.Size = new System.Drawing.Size(107, 22);
            this.ctxAbout.Text = "About";
            this.ctxAbout.Click += new System.EventHandler(this.ctxAbout_Click);
            // 
            // ctxClose
            // 
            this.ctxClose.Name = "ctxClose";
            this.ctxClose.Size = new System.Drawing.Size(107, 22);
            this.ctxClose.Text = "Close";
            this.ctxClose.Click += new System.EventHandler(this.ctxClose_Click);
            // 
            // CopyFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 230);
            this.ControlBox = false;
            this.Controls.Add(this.lblCurrentText);
            this.Controls.Add(this.lblRemainingText);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.prgCopy);
            this.Controls.Add(this.lblRemaiing);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyFiles";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Copying files";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ctxTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRemaiing;
        private System.Windows.Forms.ProgressBar prgCopy;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Label lblRemainingText;
        private System.Windows.Forms.Label lblCurrentText;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip ctxTray;
        private System.Windows.Forms.ToolStripMenuItem ctxAbout;
        private System.Windows.Forms.ToolStripMenuItem ctxClose;
    }
}